using Apsiyon.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Apsiyon.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheManager() =>  _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>(); 
        public void Add(string key, object data, int duration) => _memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));

        public T Get<T>(string key) => _memoryCache.Get<T>(key);

        public object Get(string key) => _memoryCache.Get(key);

        public bool IsAdd(string key) => _memoryCache.TryGetValue(key, out _);

        public void Remove(string key) => _memoryCache.Remove(key);

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
                _memoryCache.Remove(key);
        }
    }
}
