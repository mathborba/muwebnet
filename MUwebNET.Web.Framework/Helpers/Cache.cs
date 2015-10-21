using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System
{
    public static class CacheExtension
    {
        public static T AddCache<T>(this T objeto, string key, DateTime dataExpiraxao)
        {
            HttpContext.Current.Cache.Insert(key, objeto, null, dataExpiraxao, System.Web.Caching.Cache.NoSlidingExpiration);
            return objeto;
        }

        public static T GetCache<T>(this T objeto, string key)
        {
            return (T)HttpContext.Current.Cache.Get(key);
        }

        public static bool HasCache(this string key)
        {
            return HttpContext.Current.Cache.Get(key) != null;
        }

        public static void RemoveCache(this string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public static bool IsInCache(this string key)
        {
            return HttpContext.Current.Cache.Get(key) != null;
        }

        public static void ClearCache(string cacheKey = "")
        {
            if (cacheKey == "")
            {
                IDictionaryEnumerator cacheEnumerator = HttpContext.Current.Cache.GetEnumerator();
                while (cacheEnumerator.MoveNext())
                {
                    HttpContext.Current.Cache.Remove(cacheEnumerator.Key.ToString());
                }
            }
            else
            {
                HttpContext.Current.Cache.Remove(cacheKey);
            }
        }
    }
}
