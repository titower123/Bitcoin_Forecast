namespace Bitcoin_Forecast.Core.DTOs
{
    public class UserDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Portfolio { get; set; }


        public static implicit operator UserDTO(User other)=>
            new() 
            { 
                Id = other.Id, 
                Name = other.Name, 
                Portfolio = other.Portfolio 
            };
    }
}
