using EasyNetQ;
using IReckonu.DataImportingTool.Messaging.Abstractions;
using IReckonu.DataImportingTool.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Messaging.EasyNTQ
{
    public class EasyNetQMessagingBus : IMessagingBus
    {
        private readonly IBus _bus;
        private List<ISubscriptionResult> _subscriptionResults => new List<ISubscriptionResult>();

        public EasyNetQMessagingBus(IBus bus)
        {
            _bus = bus;
        }

        public void Publish<T>(T message) where T : class, Messages.IMessage
        {
            
            _bus.Publish(message);
        }

        public async Task PublishAsync<T>(T message) where T : class, Messages.IMessage
        {
            await _bus.PublishAsync(message);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class, Messages.IMessage
        {
            
            if (!_subscriptionResults.Any(sr => sr.ToString().Equals(typeof(T).ToString())))
            {
                _subscriptionResults.Add(_bus.Subscribe(subscriptionId, onMessage));
            }
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class, Messages.IMessage
        {
            if (!_subscriptionResults.Any(sr => sr.ToString().Equals(typeof(T).ToString())))
            {
                _subscriptionResults.Add(_bus.SubscribeAsync(subscriptionId, onMessage));
            }
        }
    }
}
