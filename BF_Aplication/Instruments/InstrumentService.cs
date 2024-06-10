using Bitcoin_Forecast.Application;
using Bitcoin_Forecast.Core.Exceptions;
using Bitcoin_Forecast.Core.Entities;

namespace Bitcoin_Forecast.Application.Instruments;

public class StockService(IRepository<Portfolio> repository) : IService
{
    private IRepository<Portfolio> Repository { get; init; } = repository;

    public async Task<IEnumerable<PortfolioDTO>> GetPortfolio(CancellationToken cancellationToken = default) =>
       (await Repository.Get(cancellationToken)).Cast<PortfolioDTO>();
}