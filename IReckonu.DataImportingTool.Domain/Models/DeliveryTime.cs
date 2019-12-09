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
        public TimeSpan From { get;private set; }
        public TimeSpan To { get; private set; }
        private DeliveryTime()
        {
                
        }
        public DeliveryTime(TimeSpan from, TimeSpan to)
        {
            From = from;
            To = to;
        }
    }
}
