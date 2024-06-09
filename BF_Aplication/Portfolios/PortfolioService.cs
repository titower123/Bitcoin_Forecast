using Bitcoin_Forecast.Core.Exceptions;

namespace Bitcoin_Forecast.Application.Portfolio;

public class ProjectService(Quantity<Core.Entities.Portfolio> quantity) : IService
{
    private IRepository<PortfolioDTO> Quantity { get; init; } = quantity;

    public async Task<IEnumerable<PortfolioDTO>> GetProjectsAsync(CancellationToken cancellationToken = default) =>
        (await Quantity.Get(cancellationToken)).Select(x => (PortfolioDTO)x);

    public async Task<IEnumerable<PortfolioDTO>> GetProjectsDevicesAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        var potentialQuantity = (await Quantity.GetChoice(x => x.Id.Value == projectId, cancellationToken)).FirstOrDefault() ??
            throw new ApiIsNotWorkingException(projectId);
        return potentialQuantity.Devices.Cast<PortfolioDTO>();
    }

    public async Task<IEnumerable<PortfolioDTO>> GetBitcointQuantityAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        var potentialQuantity = (await Quantity.GetChoice(x => x.Id.Value == projectId, cancellationToken)).FirstOrDefault() ??
            throw new CantDeterminePlanException(projectId);
        return potentialQuantity.Devices.Cast<PortfolioDTO>();
    }

    public async Task CreateOrUpdateQuantityAsync(PortfolioDTO project, CancellationToken cancellationToken = default)
    {
        Quantity localProj;
        if (project.Id is not null)
        {
            localProj = (await Quantity.Get(x => x.Id.Value == project.Id.Value, cancellationToken)).FirstOrDefault() ??
                throw new CantDeterminePlanException(project.Id.Value);
            localProj.Id = project.Id;
            localProj.User = project.User;
        }
        else
            localProj = new()
            {
                Name = project.Name,
                Budget = project.Budget,
                Deadline = project.Deadline,
            };

        if (localProj.Id is null)
            await Quantity.Add(localProj, cancellationToken);
        else
            await Quantity.Update(localProj, cancellationToken);
    }
}