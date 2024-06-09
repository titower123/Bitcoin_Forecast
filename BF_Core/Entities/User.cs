namespace Bitcoin_Forecast.Core.Entities
{
    public class User : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Portfolio> Portfolio{ get; set;}



    }
}
