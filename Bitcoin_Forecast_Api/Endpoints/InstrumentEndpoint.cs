
using Microsoft.AspNetCore.Mvc;
using Bitcoin_Forecast.Application.Projects;
using Bitcoin_Forecast.Core.DTOs;

namespace Bitcoin_Forecast_Api.Endpoints;

public static class InstrumentEndpoint
{

    public static void MapProjectEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/projects", GetPrediction);
        routes.MapPost("/projects/", AddDecision);
    }

    private static async Task<IResult> AddProject([FromBody] ProjectDTO projectDTO, ProjectService service, CancellationToken cancellationToken)
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

    private static async Task<IResult> GetProjects(ProjectService service, CancellationToken cancellationToken)
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
