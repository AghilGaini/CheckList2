﻿using Domain.Entities;
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
    public class UserRepository : GenericRepository<UserDomain>, IUserDomain
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserDomain> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(r => r.Username.ToLower() == username.ToLower());
        }
    }
}
