using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    [Serializable]
    public class Price: IEquatable<Price>
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

        public bool Equals(Price other)
        {
            return other.Value == Value && other.Discount == Discount;
        }
    }
}
