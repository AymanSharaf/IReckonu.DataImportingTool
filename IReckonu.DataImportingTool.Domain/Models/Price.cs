using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class Price
    {
        public decimal Value { get;private set; }
        public decimal Discount { get;private set; }
        public Price(decimal value, decimal discount)
        {
            Value = value;
            Discount = discount;
        }

        public decimal Total() 
        {
            return Value - (Value * (Discount / 100));
        }
    }
}
