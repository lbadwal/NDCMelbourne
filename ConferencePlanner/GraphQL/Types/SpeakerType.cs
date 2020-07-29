using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Data;
using GraphQL.DataLoader;
using HotChocolate.Types;

namespace GraphQL.Types
{
    public class SpeakerType : ObjectType<Speaker>
    {
        protected override void Configure(IObjectTypeDescriptor<Speaker> descriptor)
        {
            descriptor
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SpeakerResolvers>(t => t.GetSessionsAsync(default!, default!, default))
                .Name("sessions");
        }

        private class SpeakerResolvers
        {
            public async Task<IEnumerable<Session>> GetSessionsAsync(
                Speaker speaker,
                SessionBySpeakerIdDataLoader sessionBySpeakerId,
                CancellationToken cancellationToken) =>
                await sessionBySpeakerId.LoadAsync(speaker.Id, cancellationToken);
        }
    }
}