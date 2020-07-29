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
    public class SessionBySpeakerIdDataLoader : GroupedDataLoader<int, Session>
    {
        private readonly DbContextPool<ApplicationDbContext> _dbContextPool;

        public SessionBySpeakerIdDataLoader(DbContextPool<ApplicationDbContext> dbContextPool)
        {
            _dbContextPool = dbContextPool ?? throw new ArgumentNullException(nameof(dbContextPool));
        }

        protected override async Task<ILookup<int, Session>> LoadGroupedBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            ApplicationDbContext dbContext = _dbContextPool.Rent();
            try
            {
                List<SessionSpeaker> speakers = await dbContext.Speakers
                    .Where(speaker => keys.Contains(speaker.Id))
                    .Include(speaker => speaker.SessionSpeakers)
                    .SelectMany(speaker => speaker.SessionSpeakers)
                    .Include(sessionSpeaker => sessionSpeaker.Session)
                    .ToListAsync();

                return speakers
                    .Where(t => t.Session is { })
                    .ToLookup(t => t.SpeakerId, t => t.Session!);
            }
            finally
            {
                _dbContextPool.Return(dbContext);
            }
        }
    }
}