using System;
using NHibernate;

namespace MobileBookStore.DataContracts
{
    public interface ISessionFactoryProvider
    {
        ISessionFactory SessionFactory { get; }

        ISession Open();
    }
}
