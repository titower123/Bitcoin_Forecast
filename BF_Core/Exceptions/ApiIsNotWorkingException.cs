namespace Bitcoin_Forecast.Core.Exceptions;

public class ApiIsNotWorkingException(Guid TheReason) : Exception
{
    public override string Message => $"We can't connect to Api {TheReason}";
}