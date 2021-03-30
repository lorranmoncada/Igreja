﻿using Igreja.Core;
using System;
using System.Threading.Tasks;

namespace Igreja.Infraestructure
{
    public interface IUnitOfWork<T>: IDisposable where T : BaseEntity
    {
        IRepositoryGeneric<T> Repository { get; }
        Task<bool> Commit();
    }
}
