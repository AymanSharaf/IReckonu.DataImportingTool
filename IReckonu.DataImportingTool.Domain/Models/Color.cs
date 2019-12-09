using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Domain.Models
{
    public class Color
    {
        public int Id { get;private set; }
        public string Name { get; set; }
        private Color()
        {

        }
        public Color(string name)
        {
            Name = name;
        }
    }
}
