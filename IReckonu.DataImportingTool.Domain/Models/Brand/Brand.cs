using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    [Serializable]
    public class Brand
    {
        public int Id { get;private set; }
        public string Name { get;private set; }

        private Brand()
        {

        }
        public Brand(string name)
        {
            Name = name;
        }
    }
}
