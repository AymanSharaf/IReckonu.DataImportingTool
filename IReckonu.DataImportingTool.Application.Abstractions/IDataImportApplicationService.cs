using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.Abstractions
{
    public interface IDataImportApplicationService:IApplicationService
    {
        Task Test();
        void Test2();
    }
}
