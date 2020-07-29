using System.Collections.Generic;
using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Speakers
{
    public class AddSpeakerPayload : SpeakerPayloadBase
    {
        public AddSpeakerPayload(Speaker speaker, string? clientMutationId)
            : base(speaker, clientMutationId)
        {
        }

        public AddSpeakerPayload(IReadOnlyList<UserError> errors, string? clientMutationId)
            : base(errors, clientMutationId)
        {
        }
    }
}