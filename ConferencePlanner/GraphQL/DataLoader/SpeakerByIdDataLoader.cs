﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Data;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GraphQL.DataLoader
{
    public class SpeakerByIdDataLoader : BatchDataLoader<int, Speaker>
    {
        private readonly DbContextPool<ApplicationDbContext> _dbContextPool;

        public SpeakerByIdDataLoader(DbContextPool<ApplicationDbContext> dbContextPool)
        {
            _dbContextPool = dbContextPool ?? throw new ArgumentNullException(nameof(dbContextPool));
        }

        protected override async Task<IReadOnlyDictionary<int, Speaker>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            ApplicationDbContext dbContext = _dbContextPool.Rent();
            try
            {
                return await dbContext.Speakers
                    .Where(s => keys.Contains(s.Id))
                    .ToDictionaryAsync(t => t.Id, cancellationToken);
            }
            finally
            {
                _dbContextPool.Return(dbContext);
            }
        }
    }
}