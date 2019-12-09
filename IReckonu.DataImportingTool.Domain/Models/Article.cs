using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class Article
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public int BrandId { get; private set; }


        private readonly List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
        private Article()
        {

        }
        public Article(string code, string name, Brand brand)
        {
            Guard.Against.NullOrEmpty(code, nameof(code));
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.Null(brand, nameof(brand));

            Code = code;
            Name = name;
            BrandId = brand.Id;
        }

        public void AddProduct(string key, Price price, int size, Color color, DeliveryTime deliveryTime)
        {
            var product = new Product(key, price, size, color, deliveryTime);
            product.SetArticleId(Id); // could be removed
            _products.Add(product);
        }
    }
}
