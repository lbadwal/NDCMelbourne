﻿using System.Threading.Tasks;
using GraphQL.Data;
using GraphQL.Extensions;
using HotChocolate;

namespace GraphQL
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(
            AddSpeakerInput input,
            [ScopedService] ApplicationDbContext context)
        {
            var speaker = new Speaker
            {
                Name = input.Name,
                Bio = input.Bio,
                WebSite = input.WebSite
            };

            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker, input.ClientMutationId);
        }
    }
}