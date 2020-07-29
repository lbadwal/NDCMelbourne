namespace GraphQL
{
    public class AddSpeakerInput
    {
        public AddSpeakerInput(string name, string? bio, string? webSite, string? clientMutationId)
        {
            Name = name;
            Bio = bio;
            WebSite = webSite;
            ClientMutationId = clientMutationId;
        }

        public string Name { get; }

        public string? Bio { get; }

        public string? WebSite { get; }

        public string? ClientMutationId { get; }
    }
}