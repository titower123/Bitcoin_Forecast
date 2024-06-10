namespace Bitcoin_Forecast.Core.Entities
{
    public class Portfolio : IEntity
    {
        public Id Id { get; set; }
        public User UserName { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Instrument_Amount> Instruments { get; set; }

    }
}
