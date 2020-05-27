using IReckonu.DataImportingTool.Messaging.Messages;
using System;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Messaging.Abstractions
{
    public interface IMessagingBus
    {
        void Publish<T>(T message) where T : class, IMessage;
        Task PublishAsync<T>(T message) where T : class, IMessage;
        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class, IMessage;
        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class, IMessage;
    }
}
