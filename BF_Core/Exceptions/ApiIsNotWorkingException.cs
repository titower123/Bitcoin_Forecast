namespace Bitcoin_Forecast.Core.Exceptions;

public class ApiIsNotWorkingException(string TheReason) : Exception
{
    public override string Message => $"We can't connect to Api {TheReason}";
}