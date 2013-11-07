﻿using System.Web.Mvc;
using System.Web.Routing;
using BusConductor.Admin.UI;
using BusConductor.Data.Core;
//using NHibernate;
//using BusConductor.Application.Core;
using BusConductor.UI.Common;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace BusConductor.UI.Core
{
    public class UiRegistry : Registry
    {
        public UiRegistry()
        {
            Configure(x =>
                      {
                          //x.ImportRegistry(typeof(ApplicationRegistry));
                          x.ImportRegistry(typeof(DataRegistry));

                          //For<ISessionFactory>().Use(MvcApplication.SessionFactory);

                          //For<IUserLoginProvider>().Use<HttpContextUserLoginProvider>();

                          //For<IViewEngine>().Use<RazorViewEngine>();
                          //SetAllProperties(p => p.OfType<ISessionFactory>());
                          //FillAllPropertiesOfType<ISessionFactory>();

                      });

        }
    }
}