using System;
using System.Collections;
using System.Collections.Generic;
using StructureMap;
using Microsoft.Practices.ServiceLocation;

namespace BusConductor.Admin.UI.Common
{
    public class StructureMapServiceLocator : IServiceLocator
    {
        private IContainer _container;

        public StructureMapServiceLocator(IContainer container)
        {
            this._container = container;
        }
        #region IServiceLocator Members

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            IList list = null;
            try
            {
                list = _container.GetAllInstances(serviceType);
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            foreach (var o in list)
            {
                yield return o;
            }
        }
 
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            IList<TService> list = null;
            try
            {
                list = _container.GetAllInstances<TService>();
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            foreach (var o in list)
            {
                yield return o;
            }
        }

        public object GetInstance(Type serviceType, string key)
        {
            object o = null;
            try
            {
                o = _container.GetInstance(serviceType, key);
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            return o;
        }
     
        public object GetInstance(Type serviceType)
        {
            object o = null;
            try
            {
                o = _container.GetInstance(serviceType);
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            return o;
        }

        public TService GetInstance<TService>(string key)
        {
            TService t;
            try
            {
                t = _container.GetInstance<TService>(key);
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            return t;
        }

        public TService GetInstance<TService>()
        {
            TService t;
            try
            {
                t = _container.GetInstance<TService>();
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            return t;

        }

        #endregion

        #region IServiceProvider Members
        public object GetService(Type serviceType)
        {
            object o = null;
            try
            {
                o = GetInstance(serviceType);
            }
            catch (StructureMapException smex)
            {
                throw new ActivationException(message: smex.Message);
            }
            return o;
        }

        #endregion
    }
}
