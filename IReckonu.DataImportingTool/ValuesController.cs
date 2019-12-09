using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IReckonu.DataImportingTool.ApplicationServices.Abstractions;
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
           await _save.Save(new Brand("dddddssssssssssssd") );
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
