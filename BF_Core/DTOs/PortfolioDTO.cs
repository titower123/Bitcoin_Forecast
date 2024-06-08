using BF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Core.DTOs
{
    public class PortfolioDTO
    {
        public Id Id { get; set; }
        public string User { get; set; }
        public string Instrument { get; set; }


        public static implicit operator PortfolioDTO(Portfolio other) =>
            new()
            {
                Id = other.Id,
                User = other.User,
                Instrument = other.Instrument
            };
    }
}
