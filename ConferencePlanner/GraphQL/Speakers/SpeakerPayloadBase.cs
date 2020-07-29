using System.Collections.Generic;
using GraphQL.Common;
using GraphQL.Data;

namespace GraphQL.Speakers
{
    public class SpeakerPayloadBase : PayloadBase
    {
        public SpeakerPayloadBase(Speaker speaker, string? clientMutationId)
            : base(clientMutationId)
        {
            Speaker = speaker;
        }

        public SpeakerPayloadBase(IReadOnlyList<UserError> errors, string? clientMutationId)
            : base(errors, clientMutationId)
        {
        }

        public Speaker? Speaker { get; }
    }
}
