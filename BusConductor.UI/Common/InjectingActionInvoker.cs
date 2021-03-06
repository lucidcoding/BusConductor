﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using System.Linq;

namespace BusConductor.UI.Common
{
    public class InjectingActionInvoker : ControllerActionInvoker
    {
        private readonly IContainer _container;

        public InjectingActionInvoker(IContainer container)
        {
            _container = container;
        }

        protected override FilterInfo GetFilters(
            ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            var info = base.GetFilters(controllerContext, actionDescriptor);

            info.AuthorizationFilters.ToList().ForEach(_container.BuildUp);
            info.ActionFilters.ToList().ForEach(_container.BuildUp);
            info.ResultFilters.ToList().ForEach(_container.BuildUp);
            info.ExceptionFilters.ToList().ForEach(_container.BuildUp);

            return info;
        }
    }
}