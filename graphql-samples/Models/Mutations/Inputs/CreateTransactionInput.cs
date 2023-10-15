namespace Graphql.Api.Models.Mutations.Inputs
{
	public sealed class CreateTransactionInput
	{
		public Guid AssetId { get; set; }
		public Guid PortfolioId { get; set; }
		public decimal Amount { get; set; }
		public decimal BuyPriceUsd { get; set; }
	}
}
