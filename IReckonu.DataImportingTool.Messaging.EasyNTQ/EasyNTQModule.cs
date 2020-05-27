using Autofac;
using System;

namespace IReckonu.DataImportingTool.Messaging.EasyNTQ
{
    public class EasyNTQModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterEasyNetQ(Environment.GetEnvironmentVariable("RabbitMQConnectionString"));

            builder.RegisterType<EasyNetQMessagingBus>().AsImplementedInterfaces();

        }


    }
}
