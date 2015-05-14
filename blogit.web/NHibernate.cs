using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using BlogIT.Web.Entities;     //ProjectName.Entites
using BlogIT.Web.Controllers; //ProjectName.Controllers
namespace BlogIT.Web
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
                              @"Server=.;initial catalog=GenerateDB;integrated security=True")
                          .ShowSql()
            )
            .Mappings(m =>
                      m.FluentMappings
                          .AddFromAssemblyOf<GenerateDBController>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                                            .Execute(false, true))
            .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}