//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using StructureMap;

//namespace BusConductor.UI.Common
//{
//    public class StructureMapFilterProvider : FilterAttributeFilterProvider
//    {
//        private readonly IContainer container;

//        public StructureMapFilterProvider(IContainer container)
//        {
//            this.container = container;
//        }

//        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
//        {
//            var filters = base.GetFilters(controllerContext, actionDescriptor);

//            foreach (var filter in filters)
//                container.BuildUp(filter.Instance);

//            return filters;
//        }
//    }
//}