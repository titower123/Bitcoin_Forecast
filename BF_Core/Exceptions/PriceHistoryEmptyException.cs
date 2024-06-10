namespace Bitcoin_Forecast_Core.Exceptions;
public class PriceHistoryEmptyException(Guid id) : Exception
{
    public override string Message => $"Price history {id} is empty ";
}