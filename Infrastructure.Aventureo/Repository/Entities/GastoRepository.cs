using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.DTO;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Context;
using Infraestructure.Aventureo.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Aventureo.Repository.Entities
{
    public class GastoRepository : RepositoryBase<Gasto>, IGastoRepository
    {
        private readonly AppDbContext _context;
        public GastoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GastoDTO>> GetGastosByViaje(int id)
        {
            List<GastoDTO> gastos = await _context.Gastos.Join(_context.Categorias, gas => gas.idCategoria, cat => cat.IdCategoria,
                (gas, cat) => new GastoDTO
                {
                    idGasto = gas.idGasto,
                    nombre = gas.nombre,
                    cantidad = gas.cantidad,
                    idViaje = gas.idViaje,
                    categoria = cat.Nombre
                }).Where(g => g.idViaje == id).ToListAsync();

            if (gastos == null || !gastos.Any())
                throw new KeyNotFoundException("No se han encontrado gastos para este viaje");

            return gastos;
        }

        public async Task<List<GastoCategoriaDTO>> GetGastosCategoryByViaje(int idViaje)
        {
            List<GastoCategoriaDTO> result = await _context.Gastos
                .Join(_context.Categorias, gas => gas.idCategoria, cat => cat.IdCategoria,
                (gas, cat) => new
                {
                    gas.idViaje,
                    cat.IdCategoria,
                    CategoriaNombre = cat.Nombre,
                    gas.cantidad
                })
                .Where(g => g.idViaje == idViaje)
                .GroupBy(g => new { g.IdCategoria, g.CategoriaNombre })
                .Select(g => new GastoCategoriaDTO
                {
                    categoria = g.Key.CategoriaNombre,
                    total = g.Sum(x => x.cantidad),
                    idViaje = idViaje,
                    idCategoria = g.Key.IdCategoria
                }).ToListAsync();

            if (result == null || !result.Any())
                throw new KeyNotFoundException("No se han encontrado gastos para este viaje");

            return result;
        }
    }
}
