﻿using FastData.Model;

namespace FastData.Base
{
    /// <summary>
    /// 缓存
    /// </summary>
    internal static class DbCache
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        public static void Set(string cacheType, string key, string value, int Hours=8640)
        {
            if (cacheType.ToLower() == CacheType.WebKey)
                FastUntility.Cache.BaseCache.Set(key, value, Hours);

            if (cacheType.ToLower() == CacheType.RedisKey)
                FastRedis.RedisInfo.Set(key, value, Hours);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        public static void Set<T>(string cacheType,  string key, T value, int Hours = 8640) where T : class, new()
        {
            if (cacheType.ToLower() == CacheType.WebKey)
                FastUntility.Cache.BaseCache.Set<T>(key, value, Hours);

            if (cacheType.ToLower() == CacheType.RedisKey)
                FastRedis.RedisInfo.Set<T>(key, value, Hours);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        public static string Get(string cacheType,  string key)
        {
            if (cacheType.ToLower() == CacheType.WebKey)
               return FastUntility.Cache.BaseCache.Get(key);

            if (cacheType.ToLower() == CacheType.RedisKey)
               return FastRedis.RedisInfo.Get(key);

            return "";
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        public static T Get<T>(string cacheType,  string key) where T : class, new()
        {
            if (cacheType.ToLower() == CacheType.WebKey)
                return FastUntility.Cache.BaseCache.Get<T>(key);

            if (cacheType.ToLower() == CacheType.RedisKey)
                return FastRedis.RedisInfo.Get<T>(key);

            return new T();
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        public static void Remove(string cacheType,  string key)
        {
            if (cacheType.ToLower() == CacheType.WebKey)
                FastUntility.Cache.BaseCache.Remove(key);

            if (cacheType.ToLower() == CacheType.RedisKey)
                FastRedis.RedisInfo.Remove(key);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        public static bool Exists(string cacheType,  string key)
        {
            if (cacheType.ToLower() == CacheType.WebKey)
                FastUntility.Cache.BaseCache.Exists(key);

            if (cacheType.ToLower() == CacheType.RedisKey)
                FastRedis.RedisInfo.Exists(key);

            return false;
        }
    }
}
