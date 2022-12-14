using Domain.Interfaces;
using EFCoreDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDAL.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IPersonDomain _person { get; set; }
        public IUserDomain _user { get; set; }
        public IRoleDomain _role { get; set; }
        public IPermisionDomain _permision { get; set; }
        public IUserRoleDomain _userRole { get; set; }
        public IRolePermisionDomain _rolePermision { get; set; }

        public UnitOfWorkRepository(ApplicationContext context)
        {
            _context = context;
            _person = new PersonRepository(context);
            _user = new UserRepository(context);
            _role = new RoleRepository(context);
            _permision = new PermisionRepository(context);
            _userRole = new UserRoleRepository(context);
            _rolePermision = new RolePermisionRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
