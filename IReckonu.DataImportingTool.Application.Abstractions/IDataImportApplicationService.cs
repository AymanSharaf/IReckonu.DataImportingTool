﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.Abstractions
{
    public interface IDataImportApplicationService : IApplicationService
    {
        void ImportData(Stream streamInput);
    }
}
