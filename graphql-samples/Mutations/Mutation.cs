using Database;

using Graphql.Api.Entities;
using Graphql.Api.Exceptions;
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

		public async Task<CreateAssetPayload> CreateAssetAsync(
			ApplicationDbContext dbContext,
			CreateAssetInput input,
			CancellationToken cancellationToken)
		{
			Asset asset = new()
			{
				Name = input.Name
			};

			await dbContext.Assets.AddAsync(asset, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return new CreateAssetPayload
			{
				Asset = asset
			};
		}

		public async Task<CreateTransactionPayload> CreateTransactionAsync(
			ApplicationDbContext dbContext,
			CreateTransactionInput input,
			CancellationToken cancellationToken)
		{
			Portfolio portfolio =
				await dbContext.FindAsync<Portfolio>(input.PortfolioId)
				?? throw new UnprocessableEntityException($"Portfolio with id: '{input.PortfolioId}' was not found.");

			Asset asset = await dbContext.FindAsync<Asset>(input.AssetId)
				?? throw new UnprocessableEntityException($"Asset with id: '{input.AssetId}' was not found.");

			Transaction transaction = new()
			{
				AssetId = asset.Id,
				PortfolioId = portfolio.Id,
				Amount = input.Amount,
				BuyPriceUsd = input.BuyPriceUsd
			};

			await dbContext.Transactions.AddAsync(transaction, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return new CreateTransactionPayload
			{
				Transaction = transaction
			};
		}
	}
}
