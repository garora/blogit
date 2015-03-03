using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using blogit.;


namespace blogit.dal
{
    public class NHibernate
    {
    
            private static ISessionFactory _sessionFactory;

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
                                  .ConnectionString(
                                      @"Server=.;initial catalog=blogit;integrated security=True")
                                  .ShowSql()
                    )
                    .Mappings(m =>
                              m.FluentMappings
                                  .AddFromAssemblyOf<blogit.dal.DataModification>())
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
