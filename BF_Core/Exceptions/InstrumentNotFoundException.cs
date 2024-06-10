﻿namespace Bitcoin_Forecast.Core.Exceptions;

public class InstrumentNotFoundException(Guid id) : Exception($"Instrument {id} not found.")
{
}