using System;
using MobileBookStore.DataContracts;
using MobileBookStore.Model;

namespace MobileBookStore.Data.EventListeners
{
    public class EventListenerHelper
    {
        private readonly IPrincipalAccessor principalAccessor;

        public EventListenerHelper(IPrincipalAccessor principalAccessor)
        {
            this.principalAccessor = principalAccessor;
        }

        public void OnModify(object entity)
        {
            var savingEntity = entity as IPersistentEntity;

            if (savingEntity != null)
            {
                savingEntity.CreatedOn = DateTime.Now;
            }
        }

        public void OnCreate(object entity)
        {
            var savingEntity = entity as IPersistentEntity;

            if (savingEntity != null)
            {
                savingEntity.CreatedOn = DateTime.Now;
            }
        }

        public void OnDelete(object entity)
        {
            var deletingEntity = entity as IPersistentEntity;
        }
    }
}
