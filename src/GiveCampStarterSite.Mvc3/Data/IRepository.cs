namespace GiveCampStarterSite.Data
{
    using System;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository : IDisposable
    {
        T Get<T>(int id) where T : IEntityWithKey;
        T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntityWithKey;

        IQueryable<T> Find<T>() where T : IEntityWithKey;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : IEntityWithKey;

        T Save<T>(T entity) where T : IEntityWithKey;
        T Delete<T>(T entity) where T : IEntityWithKey;
    }
}