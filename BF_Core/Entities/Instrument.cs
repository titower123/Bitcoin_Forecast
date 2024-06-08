using Bitcoin_Forecast.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Core.Entities
{
    public class Instrument : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Figi { get; set; }
        //глобальный идентификатор финансового инструмента
        public string LastPrice { get; set; }
        public string PriceHistory { get; set; }



    }
}
