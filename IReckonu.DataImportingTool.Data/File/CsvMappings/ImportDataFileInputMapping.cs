using IReckonu.DataImportingTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser.Mapping;

namespace IReckonu.DataImportingTool.Data.File.CsvMappings
{
    public class ImportDataFileInputMapping: CsvMapping<ImportDataFileInput>
    {
        public ImportDataFileInputMapping() : base()
        {
            MapProperty(0, x => x.Key);
            MapProperty(1, x => x.ArtikelCode);
            MapProperty(2, x => x.ColorCode);
            MapProperty(3, x => x.Description);
            MapProperty(4, x => x.Price);
            MapProperty(5, x => x.DiscountPrice);
            MapProperty(6, x => x.DeliveredIn);
            MapProperty(7, x => x.Q1);
            MapProperty(8, x => x.Size);
            MapProperty(9, x => x.Color);
        }
    }
}
