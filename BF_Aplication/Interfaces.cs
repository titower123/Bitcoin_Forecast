using Bitcoin_Forecast.Core.Instrument;
using System.Diagnostics.Metrics;
namespace Bitcoin_Forecast.Application;

public interface IBitcoinPriceRepository
{
    Task<List<Instrument>> GetBitcoinPrices(DateTime Date);
}