using Microsoft.EntityFrameworkCore;
using Bitcoin_Forecast.Core;

namespace Bitcoin_Forecast_Infrastructure.Db;

public class BasicRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
{
    private static readonly ProjectContext _context = new();
    public Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
        _context.AddRangeAsync(entities, cancellationToken);

    public Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken) => 
        Task.FromResult(_context.Set<TEntity>().ToArray().AsEnumerable());

    public Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken cancellationToken) =>
        Task.FromResult(_context.Set<TEntity>().Where(predicate).ToArray().AsEnumerable());

    public Task RemoveProbability(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }, cancellationToken);

    public Task UpdateProbability(IEnumerable<TEntity> entities, CancellationToken cancellationToken) =>
        Task.Run(async () =>
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }, cancellationToken);
}