namespace Bitcoin_Forecast.Core.Entities
{
    public class Instrument_Amount
    {
        public int Counter { get; set; }
        public Portfolio Portfolio { get; set; }
        public Instrument Instrument { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<Instrument> Instruments { get; set; }
    }
}
