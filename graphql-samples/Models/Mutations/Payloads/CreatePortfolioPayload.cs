using Graphql.Api.Entities;

namespace Graphql.Api.Models.Mutations.Payloads
{
	public class CreatePortfolioPayload
	{
		public required Portfolio Portfolio { get; set; }
	}
}
