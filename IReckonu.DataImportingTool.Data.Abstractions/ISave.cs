using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Abstractions
{
    public interface ISave<T>
    {
        Task Save(T enity);
    }
}
