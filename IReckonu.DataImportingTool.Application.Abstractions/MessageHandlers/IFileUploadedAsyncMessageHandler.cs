using IReckonu.DataImportingTool.Messaging.Abstractions;
using IReckonu.DataImportingTool.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Application.Abstractions.MessageHandlers
{
    public interface IFileUploadedAsyncMessageHandler : IAsyncMessageHandler<FileUploaded>
    {
        
    }
}
