using Bitcoin_Forecast.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BF_Core.Entities
{
    public class Portfolio : IEntity
    {
        public Id Id { get; set; }
        public string User { get; set; }
        public string Instrument { get; set; }


        public virtual ICollection<Instrument> Instruments { get; set; }

    }
}
