﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationDbContext GetContext { get { return _dbContext; } }

        public Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IDisposable> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, string lockName = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
