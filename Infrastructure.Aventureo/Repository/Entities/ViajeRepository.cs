using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aventureo.Entities;
using Core.Aventureo.Interfaces.Repository.Entities;
using Infraestructure.Aventureo.Context;
using Infraestructure.Aventureo.Repository;

namespace Infrastructure.Aventureo.Repository.Entities
{
    public class ViajeRepository : RepositoryBase<Viaje>, IViajeRepository
    {
        private readonly AppDbContext _context;

        public ViajeRepository (AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task <List<Viaje>> GetViajesByUser (int userId)
        {
            List<Viaje> result = _context.Viajes.Where(v => v.idUsuario == userId).ToList();

            return result;
        }
    }
}
