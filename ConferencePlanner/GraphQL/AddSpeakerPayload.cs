using GraphQL.Data;

namespace GraphQL
{
    public class AddSpeakerPayload
    {
        public AddSpeakerPayload(Speaker speaker, string? clientMutationId)
        {
            Speaker = speaker;
            ClientMutationId = clientMutationId;
        }

        public Speaker Speaker { get; }

        public string? ClientMutationId { get; }
    }
}