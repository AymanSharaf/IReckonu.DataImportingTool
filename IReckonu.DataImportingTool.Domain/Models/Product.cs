using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get;private set; }
        //public Price Price { get; private set; }
        public TimeSpan DeliveredIn { get; private set; }
        public string Q1 { get; private set; }
        public int Size { get; private set; }
        public string Color { get; private set; }
        public Product(string description)
        {
            Description = description;
        }
    }
}
