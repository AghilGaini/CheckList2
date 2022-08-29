﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IPersonDomain _person { get; set; }
        public IUserDomain _user { get; set; }
        void Complete();
    }
}