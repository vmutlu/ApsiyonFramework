using Apsiyon.CrossCuttingConcerns.Caching;
using Apsiyon.CrossCuttingConcerns.Caching.Microsoft;
using Apsiyon.MessageBrokers.RabbitMq;
using Apsiyon.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Apsiyon.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();

            services.AddTransient<IMessageBrokerHelper, MqQueueHelper>();
            services.AddTransient<IMessageConsumer, MqConsumerHelper>();
        }
    }
}
