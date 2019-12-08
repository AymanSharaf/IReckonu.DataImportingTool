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
        public int Id { get;private set; }
        public int Code { get;private set; }
        public string Name { get;private set; }

        private readonly List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Article(int code, string name)
        {
            Guard.Against.OutOfRange(code, nameof(code), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(name, nameof(name));

            Code = code;
            Name = name;
        }
    }
}
