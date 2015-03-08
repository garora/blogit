using BlogIT.Utility;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace BlogIT.Dal
{
    internal class NHibernatecfg
    {
        private static ISessionFactory _sessionFactory;
        private const string ConfigKey = "cn";

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)

                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(Config.GetConfigValueAsString(ConfigKey))
                    .ShowSql()
                )
                .Mappings(m =>
                    m.FluentMappings
                        .AddFromAssemblyOf<CreateDB>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                    .Create(true, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}