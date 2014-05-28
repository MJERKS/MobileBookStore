using MobileBookStore.DataContracts;

using NHibernate;

namespace MobileBookStore.Data
{
    public class Repository: GenericRepositoryBase<int>, IRepository
    {
        public Repository(ISessionFactoryProvider sessionFactoryProvider)
            : base(sessionFactoryProvider)
        {
        }

        public Repository(ISession session)
            : base(session)
        {
        }
    }  
}
