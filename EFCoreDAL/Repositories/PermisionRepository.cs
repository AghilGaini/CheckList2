using Domain.DTO.Security;
using Domain.Entities;
using Domain.Interfaces;
using EFCoreDAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDAL.Repositories
{
    public class PermisionRepository : GenericRepository<PermisionDomain>, IPermisionDomain
    {
        private readonly ApplicationContext _context;

        public PermisionRepository(ApplicationContext context) : base(context)

        {
            _context = context;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<PermisionDomain> list)
        {
            try
            {
                if (list == null)
                    return true;

                await _context.Permisions.AddRangeAsync(list);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<PermisionInfoDTO>> GetAllDTOAsync()
        {
            return await _context.Permisions.Select(r => new PermisionInfoDTO() { Id = r.Id, Title = r.Title, Value = r.Value }).ToListAsync();
        }

    }
}
