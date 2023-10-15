using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Graphql.Api.Entities
{
	[PrimaryKey(nameof(Id))]
	public class Transaction
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		public required Guid PortfolioId { get; set; }

		[ForeignKey(nameof(PortfolioId))]
		public Portfolio? Portfolio { get; set; }

		[Required]
		public required Guid AssetId { get; set; }

		[ForeignKey(nameof(AssetId))]
		public Asset? Asset { get; set; }

		public required decimal Amount { get; set; }
		public required decimal BuyPriceUsd { get; set; }
	}
}
