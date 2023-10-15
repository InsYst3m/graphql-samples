using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Graphql.Api.Entities
{
	[PrimaryKey(nameof(Id))]
	public class Portfolio
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		public required string Name { get; set; }

		public List<Transaction> Transactions { get; set; } = new();
	}
}
