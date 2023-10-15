using Graphql.Api.Entities;

namespace Graphql.Api.Models.Mutations.Payloads
{
	public sealed class CreateAssetPayload
	{
		public required Asset Asset { get; set; }
	}
}
