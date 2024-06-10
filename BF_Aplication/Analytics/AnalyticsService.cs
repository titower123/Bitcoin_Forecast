using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class AnalyticsService
{
    public AnalyticsResult DummyMovingAverageInOutAnalytics(Instrument instrument)
    {
        var priceHistory = JsonSerializer.Deserialize<List<double>>(instrument.PriceHistory);

        if (priceHistory == null || !priceHistory.Any())
        {
            throw new ArgumentException("Price history is invalid or empty.");
        }

        var movingAverage = priceHistory.Average();
        var deviation = (instrument.LastPrice - movingAverage) / movingAverage;

        string recommendation;
        if (instrument.LastPrice > movingAverage * 1.05)
        {
            recommendation = instrument.IsInPortfolio ? "Sell" : "Don't Enter";
        }
        else if (instrument.LastPrice < movingAverage * 0.95)
        {
            recommendation = "Buy";
        }
        else
        {
            recommendation = "Hold";
        }

        return new AnalyticsResult
        {
            Recommendation = recommendation,
            DeviationCoefficient = deviation
        };
    }
}

public class AnalyticsResult
{
    public string Recommendation { get; set; }
    public double DeviationCoefficient { get; set; }
}