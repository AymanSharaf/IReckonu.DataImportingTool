using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    [Serializable] // Not Sure about this, this was only added to support serialization to cache
    public class Article
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public int BrandId { get; private set; }
        public int TargetGroupId { get; private set; }

        private readonly List<Product> _products = new List<Product>();

        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        private Article()
        {

        }
        public Article(string code, string name, int brandId, int targetGroupId)
        {
            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.NullOrEmpty(name, nameof(name));

            Code = code;
            Name = name;
            BrandId = brandId;
            TargetGroupId = targetGroupId;
        }
        public void AddProduct(string key, Price price, int size, int colorId, int deliveryTimeId)
        {

            var existingProduct = _products.SingleOrDefault(p =>
                                            p.Key.Equals(key) &&
                                            p.Price.Equals(price) &&
                                            p.Size == size &&
                                            p.ColorId == colorId &&
                                            p.DeliveryTimeId == deliveryTimeId);
            if (existingProduct == null)
            {
                var product = new Product(key, price, size, colorId, deliveryTimeId);
                _products.Add(product);
            }
        }
    }


}
