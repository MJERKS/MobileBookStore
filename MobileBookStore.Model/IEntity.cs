using System;

namespace MobileBookStore.Model
{
    public interface IEntity
    {
        object Id { get; set; }
    }

    public interface IPersistentEntity : IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        DateTime? DeletedOn { get; set; }
    }

    public interface IEntity<TId> : IEntity where TId : struct
    {
        new TId Id { get; set; }
    }

    public interface IPersistentEntity<TId> : IPersistentEntity, IEntity<TId> where TId : struct
    {
    }
}
