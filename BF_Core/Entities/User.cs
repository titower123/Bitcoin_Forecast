using Bitcoin_Forecast.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF_Core.Entities
{
    public class User : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Partfolio { get; set; }

        public virtual ICollection<Portfolio> Portfolio{ get; set;}



    }
}
