namespace Bitcoin_Forecast.Core.DTOs
{
    public class InstrumentDTO
    {
        public Id Id { get; set; }
        public string Figi { get; set; }
        //глобальный идентификатор финансового инструмента
        public string LastPrice { get; set; }
        public string PriceHistory { get; set; }



        public static implicit operator InstrumentDTO(Instrument other) =>
            new()
            {
                Id = other.Id,
                Figi = other.Figi,
                LastPrice = other.LastPrice,
                PriceHistory = other.PriceHistory
            };
    }
}
