using Bitcoin_Forecast.Core.Exceptions;
using Bitcoin_Forecast.Core.Entities;


namespace Bitcoin_Forecast.Application.Portfolios;

public class PortfolioService(IRepository<Portfolio> repository) : IService
{
    private IRepository<Portfolio> Repository { get; init; } = repository;

    public async Task CreatePortfolio(string newUser, CancellationToken cancellationToken = default)
    {
        var potentialCopies = await Repository.GetWithoutTracking(x => x.Name.Equals(newUser.ToLower(), StringComparison.CurrentCultureIgnoreCase), cancellationToken);
        if (potentialCopies.Any())
            throw new SamePortfolioException(newUser);
        await Repository.Add(new() { Name = newUser.Trim() }, cancellationToken);
    }
    public async Task BuyInstruments(Guid portfolioId, Instrument_Amount instrument, CancellationToken cancellationToken = default)
    {
        var portfolio = (await Repository.Get(x => x.Id.Value == portfolioId, cancellationToken)).FirstOrDefault() ??
            throw new PortfolioDoesntExistException(portfolioId);

        var oldInstrument = portfolio.Instruments.FirstOrDefault(x => x.Instrument == instrument.Instrument);
        if (oldInstrument is null)
            portfolio.Instruments.Add(new()
            {
                Instrument = instrument.Instrument,
                Amount = instrument.Amount
            });
        else
            oldInstrument.Amount += instrument.Amount;

        await Repository.Update(portfolio, cancellationToken);
    }

    public async Task<IEnumerable<Portfolio>> GetBitcointQuantityAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        var potentialQuantity = (await Repository.Get(x => x.Id.Value == projectId, cancellationToken)).FirstOrDefault() ??
            throw new CantDeterminePlanException(projectId);
        return potentialQuantity.Instruments.Cast<Portfolio>();
    }

    public async Task SellInstruments(Guid portfolioId, Guid instrumentId, Instrument_Amount instrument, CancellationToken cancellationToken = default)
    {
        var portfolio = (await Repository.Get(x => x.Id.Value == portfolioId, cancellationToken)).FirstOrDefault() ??
            throw new PortfolioDoesntExistException(portfolioId);

        var oldInstrument = portfolio.Instruments.FirstOrDefault(x => x.Instrument == instrument.Instrument) ??
            throw new InstrumentNotFoundException(instrumentId);

        if ((oldInstrument.Amount - instrument.Amount) >= 0)
            oldInstrument.Amount -= instrument.Amount;
        else
            throw new ImposibleToSellException(instrumentId, instrument.Amount);

        if (oldInstrument.Amount == 0)
            portfolio.Instruments.Remove(oldInstrument);

        await Repository.Update(portfolio, cancellationToken);
    }
}