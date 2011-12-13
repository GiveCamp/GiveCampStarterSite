namespace GiveCampStarterSite.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class CachedRepository : ICachedRepository
    {
        private readonly IRepository repository;

        private static readonly object CacheLockObject = new object();

        public CachedRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntityWithKey
        {
            string cacheKey = predicate.ToString();

            var result = (T)HttpRuntime.Cache[cacheKey];

            if (result == null)
            {
                lock(CacheLockObject)
                {
                    result = (T)HttpRuntime.Cache[cacheKey];
                    if (result == null)
                    {
                        result = repository.Get(predicate);

                        if (result != null)
                            HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                    }
                }
            }
            return (T)result;
        }

        public IQueryable<T> Find<T>() where T : IEntityWithKey
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : IEntityWithKey
        {
            var cacheKey = predicate.ToString();

            var result = HttpRuntime.Cache[cacheKey] as IQueryable<T>;

            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = (T)HttpRuntime.Cache[cacheKey] as IQueryable<T>;
                    if (result == null)
                    {
                        result = repository.Get(predicate) as IQueryable<T>;
                        
                        if (result == null)
                        {
                            result = new List<T>().AsQueryable();
                        } else {
                            HttpRuntime.Cache.Insert(cacheKey, result, null, DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                        }
                    }
                }
            }
            return result;
        }

        public T Save<T>(T entity) where T : IEntityWithKey
        {
            throw new NotImplementedException();
        }

        public T Delete<T>(T entity) where T : IEntityWithKey
        {
            throw new NotImplementedException();
        }
    }
}