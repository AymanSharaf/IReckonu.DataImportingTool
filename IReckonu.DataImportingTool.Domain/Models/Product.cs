using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class Product
    {
        public int Id { get;private set; }
        public string Key { get;private set; }
        public Price Price { get; private set; } // Value Object
        public int Size { get; private set; }
        public int ArticleId { get; private set; }
        public int ColorId { get; private set; }
        public int DeliveryTimeId { get; private set; }

        private Product()
        {
                
        }
        public Product(string key, Price price, int size,int colorId, int deliveryTimeId)
        {
            Key = key;
            Price = price;
            Size = size;
            ColorId = colorId;
            DeliveryTimeId = deliveryTimeId;
        }
    }
}
