using Database;

using Graphql.Api.Entities;
using Graphql.Api.Models.Mutations.Inputs;
using Graphql.Api.Models.Mutations.Payloads;
using Graphql.Api.Models.Subscriptions;
using Graphql.Api.Subscriptions;

using HotChocolate.Subscriptions;

namespace Graphql.Api.Mutations
{
	public class Mutation
	{
		public async Task<CreatePortfolioPayload> CreatePortfolioAsync(
			ApplicationDbContext dbContext,
			ITopicEventSender eventSender,
			CreatePortfolioInput input,
			CancellationToken cancellationToken)
		{
			Portfolio portfolio = new()
			{
				Name = input.Name
			};

			await dbContext.Portfolios.AddAsync(portfolio, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			await eventSender.SendAsync(
				nameof(Subscription.OnPortfolioCreated),
				new OnPortfolioCreatedPayload
				{
					Portfolio = portfolio
				},
				cancellationToken);

			return new CreatePortfolioPayload
			{
				Portfolio = portfolio
			};
		}
	}
}
