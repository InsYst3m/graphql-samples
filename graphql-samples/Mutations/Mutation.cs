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
			CreatePortfolioInput input,
			ITopicEventSender eventSender,
			CancellationToken cancellationToken)
		{
			Portfolio portfolio = new()
			{
				Id = Guid.NewGuid(),
				Name = input.Name
			};

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
