using FluentNHibernate.Mapping;

namespace MobileBookStore.Model
{
    public abstract class EntityMapBase<TEntity> : ClassMap<TEntity>
        where TEntity : IEntity<int>
    {
        protected EntityMapBase()
        {
            Id(x => x.Id).GeneratedBy.Identity();
        }
    }
}
