using Graphql.Api.Entities;

namespace Graphql.Api.Models.Mutations.Payloads
{
	public sealed class CreateTransactionPayload
	{
		public required Transaction Transaction { get; set; }
	}
}
