namespace Bitcoin_Forecast.Core.Entities
{
    public class Portfolio : IEntity
    {
        public Id Id { get; set; }
        public User User { get; set; }
        public virtual ICollection<Instrument_amount> Instruments { get; set; }

    }
}
