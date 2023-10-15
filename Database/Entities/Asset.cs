using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace Graphql.Api.Entities
{
	[PrimaryKey(nameof(Id))]
	public class Asset
	{
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[Required]
		public required string Name { get; set; }
	}
}
