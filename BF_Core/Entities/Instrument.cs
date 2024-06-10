namespace Bitcoin_Forecast.Core.Entities
{
    public class Instrument : IEntity
    {
        public Id Id { get; set; }
        public string Figi { get; set; }
        //глобальный идентификатор финансового инструмента
        public string Name { get; set; }

        public double LastPrice { get; set; }
        public string PriceHistory { get; set; }




    }
}
