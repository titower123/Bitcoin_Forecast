using BF_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Core.DTOs
{
    public class InstrumentDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Figi { get; set; }
        public string LastPrice { get; set; }
        public string PriceHistory { get; set; }


        public static implicit operator InstrumentDTO(Instrument other) =>
            new()
            {
                Id = other.Id,
                Name = other.Name,
                Figi = other.Figi,
                LastPrice = other.LastPrice,
                PriceHistory = other.PriceHistory
            };
    }
}
