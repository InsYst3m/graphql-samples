using Graphql.Api.Models.Subscriptions;

namespace Graphql.Api.Subscriptions
{
	public class Subscription
	{
		[Subscribe]
		public OnPortfolioCreatedPayload OnPortfolioCreated([EventMessage] OnPortfolioCreatedPayload payload)
		{
			return payload;
		}
	}
}
