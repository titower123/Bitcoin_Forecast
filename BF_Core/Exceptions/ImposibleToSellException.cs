namespace Bitcoin_Forecast.Core.Exceptions;

public class ImposibleToSellException(Guid id, int amount) : Exception($"Instrument {id} can't sell in a given quantity {amount}")
{
}