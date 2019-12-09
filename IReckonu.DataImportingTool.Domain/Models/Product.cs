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
        private Color _color;
        private DeliveryTime _deliveryTime;
        private Product()
        {
                
        }
        public Product(string key, Price price, int size,Color color, DeliveryTime deliveryTime)
        {
            Key = key;
            Price = price;
            Size = size;
            ColorId = color.Id;
            _color = color;
            _deliveryTime = deliveryTime;
            DeliveryTimeId = deliveryTime.Id;
        }
        internal void SetArticleId(int articleId) 
        {
            ArticleId = articleId;
        }
    }
}
