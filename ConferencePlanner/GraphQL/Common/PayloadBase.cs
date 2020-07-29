using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Common
{
    public class PayloadBase
    {
        protected PayloadBase(string? clientMutationId)
        {
            Errors = Array.Empty<UserError>(); ;
            ClientMutationId = clientMutationId;
        }

        protected PayloadBase(IReadOnlyList<UserError> errors, string? clientMutationId)
        {
            Errors = errors;
            ClientMutationId = clientMutationId;
        }

        public IReadOnlyList<UserError> Errors { get; }

        public string? ClientMutationId { get; }
    }
}
