using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class DeliveryTime
    {
        public int Id { get;private set; }
        public long From { get;private set; }
        public long To { get; private set; }
        private DeliveryTime()
        {
                
        }
        public DeliveryTime(TimeSpan from, TimeSpan to)
        {
            From = from.Ticks;
            To = to.Ticks;
        }
    }
}
