using IReckonu.DataImportingTool.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Messaging.Abstractions
{
    public interface IAsyncMessageHandler<T> where T: IMessage
    {
        Task Handle(T message);
    }
}
