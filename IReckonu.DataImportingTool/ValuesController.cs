using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace IReckonu.DataImportingTool.API
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ISave _save;

        public ValuesController(ISave save)
        {
            _save = save;
        }
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {

            var targetGroup = new TargetGroup("baby");
            var article = new Article("1", "22", new Brand("XYZ"), targetGroup);
            targetGroup.AddArticle(article);
            article.AddProduct("Keey", new Price(100, 10), 10, new Color("Reeed"), new DeliveryTime(TimeSpan.FromDays(1), TimeSpan.FromDays(3)));
            await _save.Save(article);
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody]string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
