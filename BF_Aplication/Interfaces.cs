namespace Bitcoin_Forecast.Application;

public interface IService;
public interface IBitcoinPriceRepository
{
    Task<List<Instrument>> GetBitcoinPricesAsync(DateTime startDate, DateTime endDate);
}