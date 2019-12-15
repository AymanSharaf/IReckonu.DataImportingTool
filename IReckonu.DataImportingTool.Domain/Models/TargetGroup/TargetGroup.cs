using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    [Serializable]
    public class TargetGroup
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

        private readonly List<Article> _articles = new List<Article>();
     

        private TargetGroup()
        {

        }

        public TargetGroup(string name)
        {
            Name = name;
        }

        public void AddArticle(string code, string name,int brandId) // SRP Violation ?
        {
            // Validation on incoming Article
            var exisitngArticle = _articles.SingleOrDefault(a => a.Code == code && a.Name == name && a.BrandId == brandId);
            if (exisitngArticle == null)
            {
                _articles.Add(new Article(code, name, brandId, Id));
            }
        }
    }
}
