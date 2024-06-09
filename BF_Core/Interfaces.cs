﻿namespace Bitcoin_Forecast.Core;

public record Id(Guid Value);
public interface IEntity
{
    Id Id { get; }
}

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task Add(TEntity entity, CancellationToken cancellationToken) =>
        AddRange([entity], cancellationToken);

    Task UpdateRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task Update(TEntity entity, CancellationToken cancellationToken) =>
        UpdateRange([entity], cancellationToken);
    Task RemoveRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task Remove(TEntity entity, CancellationToken cancellationToken) =>
        RemoveRange([entity], cancellationToken);

    Task<IEnumerable<TEntity>> Get(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> Get(Func<TEntity, bool> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetWithoutTracking(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetWithoutTracking(Func<TEntity, bool> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> BitcoinPredict(Instrument instrument);
    Task<IEnumerable<TEntity>> BitcoinPredict(Func<TEntity, bool> predicate);
}