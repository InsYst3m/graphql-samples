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
		public required Guid Id { get; set; }
	}
}
