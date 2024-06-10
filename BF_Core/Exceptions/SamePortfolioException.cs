namespace Bitcoin_Forecast.Core.Exceptions;

public class SamePortfolioException(string newName) : Exception
{
    public override string Message => $"There is already a portfolio with this {newName} here ";
}