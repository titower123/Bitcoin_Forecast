namespace Bitcoin_Forecast.Core.Exceptions;

public class PortfolioDoesntExistException(Guid id) : Exception($"Portfolio {id} not found.")
{
}