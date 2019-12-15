using IReckonu.DataImportingTool.Data.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Caching
{
    public class CachingSaveServiceDecorator : ISave // not Finished..So it is not used
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ISave _save;

        public CachingSaveServiceDecorator(IDistributedCache distributedCache, ISave save)
        {
           _distributedCache = distributedCache;
           _save = save;
        }
        public async Task Save<T>(T entity)
        {
            await _save.Save(entity);

            var cachingKey = typeof(T).Name;

            var cachedEntites = await _distributedCache.GetAsync<List<T>>(cachingKey) ?? new List<T>();
            var cachedEntity = cachedEntites.AsQueryable().SingleOrDefault(a=> a.Equals(entity));
            if (cachedEntity == null) 
            {
                cachedEntites.Add(entity);
            }
        }
    }
}
