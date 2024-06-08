using Bitcoin_Forecast.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Core.Entities
{
    public class Instrument_amount
    {
        public int Amount { get; set; }
        public Portfolio Portfolio { get; set; }

        public virtual ICollection<Instrument_amount> Instruments_amount { get; set; }
    }
}
