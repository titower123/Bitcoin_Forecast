
using Microsoft.AspNetCore.Mvc;
using Bitcoin_Forecast;
using Bitcoin_Forecast.Core.DTOs;

namespace Bitcoin_Forecast_Api.Endpoints;

public static class InstrumentEndpoint
{

    public static void PortfolioEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/portfolio/create", AddDecision).WithTags("Portfolio");
        routes.MapGet("/portfolios", GetPrediction).WithTags("Portfolios");
    }
    [HttpPost]
    private static async Task<IResult> AddDecision(Bitcoin_Forecast.Core.DTOs.Portfolio portfolioDTO, PortfolioService service, CancellationToken cancellationToken)
    {
        try
        {
            await service.CreateOrUpdateProjectAsync(projectDTO, cancellationToken);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> GetPrediction(ProjectService service, CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await service.GetProjectsAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
