using Graphql.Api.Entities;

namespace Graphql.Api.Models.Mutations.Payloads
{
	public sealed class CreatePortfolioPayload
	{
		public required Portfolio Portfolio { get; set; }
	}
}
