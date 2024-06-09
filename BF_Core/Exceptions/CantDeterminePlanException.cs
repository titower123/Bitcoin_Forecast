namespace Bitcoin_Forecast.Core.Exceptions;

public class CantDeterminePlanException(Guid UnPredictable)  : Exception($"Decision {UnPredictable} can't be determined.") { }