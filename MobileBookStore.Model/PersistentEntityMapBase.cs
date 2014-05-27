namespace MobileBookStore.Model
{
    public abstract class PersistentEntityMapBase<TEntity> : EntityMapBase<TEntity> where TEntity : IPersistentEntity<int>
    {
        protected PersistentEntityMapBase()
        {
            Map(x => x.CreatedOn).Not.Nullable();
        }
    }
}