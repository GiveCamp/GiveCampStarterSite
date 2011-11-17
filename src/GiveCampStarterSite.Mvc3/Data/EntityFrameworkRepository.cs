namespace GiveCampStarterSite.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Metadata.Edm;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.Linq.Expressions;

    using GiveCampStarterSite.Models;

    public class EntityFrameworkRepository : IRepository
    {
        private readonly ObjectContext context;

        public EntityFrameworkRepository()
        {
            context = new GiveCampEntities();
        }

        public T Get<T>(int id) where T : IEntityWithKey
        {
            return context.CreateObjectSet<T>().SingleOrDefault(x => x.Id == id);

        }

        public T Get<T>(Expression<Func<T, bool>> predicate) where T : IEntityWithKey
        {
            return context.CreateQuery<T>("[" + context.GetEntitySet<T>().Name + "]")
                .Where(predicate)
                .FirstOrDefault();
        }

        public IQueryable<T> Find<T>() where T : IEntityWithKey
        {
            return context.CreateQuery<T>("[" + context.GetEntitySet<T>().Name + "]");
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate) where T : IEntityWithKey
        {
            return context
                .CreateQuery<T>("[" + context.GetEntitySet<T>().Name + "]")
                .Where(predicate);
        }

        public T Save<T>(T entity) where T : IEntityWithKey
        {
            object originalItem;

            if (context.TryGetObjectByKey(entity.EntityKey, out originalItem))
                context.ApplyPropertyChanges(entity.EntityKey.EntitySetName, entity);
            else
                context.AddObject(entity.EntityKey.EntitySetName, entity);

            context.SaveChanges();

            return entity;
        }

        public T Delete<T>(T entity) where T : IEntityWithKey
        {
            context.DeleteObject(entity);
            context.SaveChanges();

            return entity;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

    public static class ObjectContextExtensions
    {
        internal static EntitySetBase GetEntitySet<TEntity>(this ObjectContext context)
        {
            EntityContainer container = context
                .MetadataWorkspace
                .GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);

            Type baseType = GetBaseType(typeof(TEntity));
            EntitySetBase entitySet = container
                .BaseEntitySets
                .Where(item => item.ElementType.Name.Equals(baseType.Name))
                .FirstOrDefault();

            return entitySet;
        }

        private static Type GetBaseType(Type type)
        {
            Type baseType = type.BaseType;

            if (baseType != null && baseType != typeof(EntityObject))
                return GetBaseType(type.BaseType);
            return type;
        }
    }
}