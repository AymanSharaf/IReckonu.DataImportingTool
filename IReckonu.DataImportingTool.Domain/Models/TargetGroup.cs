using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class TargetGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private readonly List<Article> _articles = new List<Article>();
        public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

        private TargetGroup()
        {
                
        }

        public TargetGroup(string name)
        {
            Name = name;
        }

        public void AddArticle(Article article) 
        {
            // Validation on incoming Article
            _articles.Add(article);
        }
    }
}
