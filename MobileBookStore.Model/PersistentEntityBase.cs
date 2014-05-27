using System;

namespace MobileBookStore.Model
{
    public abstract class PersistentEntityBase<TEntity> : EntityBase<TEntity>, IPersistentEntity<int>
        where TEntity : class, IPersistentEntity<int>
    {
        public virtual DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, CreatedOn: {1}", base.ToString(), this.CreatedOn);
        }
    }
}