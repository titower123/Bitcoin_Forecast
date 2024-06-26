﻿namespace Bitcoin_Forecast.Core.DTOs
{
    public class PortfolioDTO
    {
        public Id Id { get; set; }
        public User User { get; set; }

        public static implicit operator PortfolioDTO(Entities.Portfolio other) =>
            new()
            {
                Id = other.Id,
                User = other.UserName
            };
    }
}
