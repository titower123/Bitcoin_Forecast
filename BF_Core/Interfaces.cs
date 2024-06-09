namespace Bitcoin_Forecast.Core;

public record Id(Guid Value);
public interface IEntity
{
    Id Id { get; }
}

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task AddDecision(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task Add(TEntity entity, CancellationToken cancellationToken) =>
        AddDecision([entity], cancellationToken);

    Task UpdateDecision(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task Update(TEntity entity, CancellationToken cancellationToken) =>
        UpdateDecision([entity], cancellationToken);
    Task RemoveDecision(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task Remove(TEntity entity, CancellationToken cancellationToken) =>
        RemoveDecision([entity], cancellationToken);

    Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> BitcoinPredict(Instrument instrument);
    Task<IEnumerable<TEntity>> BitcoinPredict(Func<TEntity, bool> predicate);
}