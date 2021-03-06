﻿using IReckonu.DataImportingTool.Data.Abstractions;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IReckonu.DataImportingTool.Data.Caching
{
    public class CachedGetService : IGet
    {
        private readonly IGet _get;
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _distributedCacheEntryOptions;

        public CachedGetService(IGet get, IDistributedCache distributedCache)
        {
            _get = get;
            _distributedCache = distributedCache;
            _distributedCacheEntryOptions = new DistributedCacheEntryOptions()
                                            .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        }
        public async Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var cachingKey = typeof(T).Name;

            var cachedEntites = await _distributedCache.GetAsync<List<T>>(cachingKey) ?? new List<T>();
            var cachedEntity = cachedEntites.AsQueryable().SingleOrDefault(predicate);

            if (cachedEntity == null)
            {
                cachedEntity = await _get.Get<T>(predicate);

                if (cachedEntity != null) 
                {
                    cachedEntites.Add(cachedEntity);
                    await _distributedCache.SetAsync<List<T>>(cachingKey, cachedEntites, _distributedCacheEntryOptions);
                }              
            }
            return cachedEntity;
        }
    }
}
