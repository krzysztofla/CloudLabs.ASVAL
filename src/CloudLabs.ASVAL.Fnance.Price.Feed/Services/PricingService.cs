using Bogus;
using CloudLabs.ASVAL.Fnance.Price.Feed.ValueObjects;
using Grpc.Core;

namespace CloudLabs.ASVAL.Fnance.Price.Feed.Services;

public class PricingService : PricingFeed.PricingFeedBase
{
    private readonly ILogger<PricingService> _logger;

    public PricingService(ILogger<PricingService> logger)
    {
        _logger = logger;
    }

    public override async Task SubscribePricing(PricingRequest request,
        IServerStreamWriter<PricingResponse> responseStream, ServerCallContext context)
    {
        while (!context.CancellationToken.IsCancellationRequested)
        {
            Thread.Sleep(2000);
            var price = new Faker<Pricing>()
                .RuleFor(p => p.Value, x => x.Random.Int(0, 10000))
                .RuleFor(p => p.Symbol, x => x.Finance.Currency().Description)
                .RuleFor(p => p.Datetime, _ => _.Date.Past().Ticks)
                .Generate();

            await responseStream.WriteAsync(new PricingResponse()
            {
                Value = price.Value,
                Symbol = price.Symbol,
                Timestamp = price.Datetime
            });
        }
    }
}