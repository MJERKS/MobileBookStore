using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using MobileBookStore.Data.DataContext.Conventions;
using MobileBookStore.Data.EventListeners;
using MobileBookStore.DataContracts;
using MobileBookStore.Model;
using NHibernate;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;

namespace MobileBookStore.Data.DataContext
{
    public class SessionFactoryProvider : ISessionFactoryProvider
    {
        private readonly static object LockObject = new object();

        private volatile ISessionFactory sessionFactory;

        private IPrincipalAccessor principalAccessor;

        public SessionFactoryProvider(IPrincipalAccessor principalAccessor)
        {
            this.principalAccessor = principalAccessor;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    lock (LockObject)
                    {
                        if (sessionFactory == null)
                        {
                            sessionFactory = CreateSessionFactory();
                        }
                    }
                }

                return sessionFactory;
            }
        }

        public ISession Open()
        {
            return SessionFactory.OpenSession();
        }

        private ISessionFactory CreateSessionFactory()
        {                  
            //var eventListenerHelper = new EventListenerHelper(principalAccessor);
            //var saveOrUpdateEventListener = new SaveOrUpdateEventListener(eventListenerHelper);
            //var deleteEventListener = new DeleteEventListener(eventListenerHelper);

            var configuration = Fluently.Configure()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IEntity>()
                    .Conventions.Add(ForeignKey.EndsWith("Id"))
                    .Conventions.Add<EnumConvention>())

                //.ExposeConfiguration(c => c.SetListener(ListenerType.Delete, deleteEventListener))
                //.ExposeConfiguration(c => c.SetListener(ListenerType.SaveUpdate, saveOrUpdateEventListener))
                //.ExposeConfiguration(c => c.SetListener(ListenerType.Save, saveOrUpdateEventListener))
                //.ExposeConfiguration(c => c.SetListener(ListenerType.Update, saveOrUpdateEventListener))

                .BuildConfiguration();
            SchemaMetadataUpdater.QuoteTableAndColumns(configuration);

            return configuration.BuildSessionFactory();

        }
    }
}