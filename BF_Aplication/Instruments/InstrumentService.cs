using System.Diagnostics.Metrics;

namespace Bitcoin_Forecast.Application.Instruments;

public class InstrumentService(IRepository<Instrument> repository) : IService
{
    private IRepository<Instrument> Repository { get; init; } = repository;

    public async Task<IEnumerable<InstrumentDTO>> GetInstrumentsAsync(CancellationToken cancellationToken = default) =>
        (await Repository.Get(cancellationToken)).Select(x => (InstrumentDTO)x);

    public async Task UpdateInstrumentsAsync(IEnumerable<InstrumentDTO> Instruments, CancellationToken cancellationToken = default)
    {
        var newInstruments = from Instrument in Instruments
                         where Instrument.Id is null
                         select new Instrument()
                         {
                             Quantity = instrument.Quantity,
                             Name = instrument.Name
                         };

        var repo = await Repository.Get(cancellationToken);
        var newOldInstrumentCouples = from instrument in (from instrument in instruments where instrument.Id is not null select instrument)
                                  join repInstrument in repo on instrument.Id equals repInstrument.Id
                                  select (instrument, repInstrument);

        foreach (var (updatedInstrument, oldInstrument) in newOldInstrumentCouples)
        {
            oldInstrument.Quantity = updatedInstrument.Quantity;
            oldInstrument.Productivity = updatedInstrument.Productivity;
        }

        // todo: validation object
        await Repository.AddQuantity(newInstruments, cancellationToken);
        await Repository.UpdateQuantity(repo, cancellationToken);
    }
}