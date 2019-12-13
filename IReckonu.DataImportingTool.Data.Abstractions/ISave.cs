using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions
{
    public interface ISave
    {
        Task Save<T>(T entity);
    }
}
