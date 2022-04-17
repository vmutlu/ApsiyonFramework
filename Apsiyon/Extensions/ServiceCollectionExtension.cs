using Apsiyon.ActionFilters.Abstract;
using Apsiyon.ActionFilters.Attributes;
using Apsiyon.Implementations;
using Apsiyon.Models;
using Apsiyon.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedLockNet;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace Apsiyon.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRateLimitService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RateLimitOptions>(configuration.GetSection("RateLimitOption"));
            
            services.AddScoped<RateLimitAttribute>();

            var options = new RateLimitOptions();
            configuration.GetSection("RateLimitOption").Bind(options);
            if (options.HasRedis)
            {
                services.AddScoped<IRateLimitService, RedisRateLimitService>();
                services.AddSingleton<IRateLimitBackgroundTaskQueue, RateLimitBackgroundTaskQueue>();
                services.AddHostedService<QueuedHostedService>();

                //configure redis 
                var redisConfig = ConfigurationOptions.Parse(options.RedisConnection);
                services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConfig));
                services.AddTransient<IDatabase>(provider => provider.GetRequiredService<IConnectionMultiplexer>().GetDatabase());

                services.AddSingleton<IDistributedLockFactory>(provider =>
                {
                    var config = ConfigurationOptions.Parse(options.RedisConnection);

                    return RedLockFactory.Create(new List<RedLockMultiplexer>()
                    {
                        ConnectionMultiplexer.Connect(config)
                    });
                });
            }
            
            else
            {
                services.AddMemoryCache();
                services.AddScoped<IRateLimitService, InMemoryRateLimitService>();
            }
        }
    }
}
