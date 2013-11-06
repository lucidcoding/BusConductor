using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Criterion;
using BusConductor.Domain.Common;

namespace BusConductor.Data.Common
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected readonly ISessionFactory _sessionFactory;

        protected Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        private static ProxyFactoryFactory _pff;

        protected ISession Session
        {
            get { return _sessionFactory.GetCurrentSession(); }
        }

        //public virtual void SaveOrUpdate(TEntity obj)
        //{
        //    Session.SaveOrUpdate(obj);
        //}

        public virtual void Save(TEntity obj)
        {
            Session.Save(obj);
        }

        public virtual void Update(TEntity obj)
        {
            Session.Update(obj);
        }

        public virtual TEntity GetById(TId id)
        {
            return Session.Get<TEntity>(id);
        }

        public virtual TEntity LoadById(TId id)
        {
            return Session.Load<TEntity>(id);
        }

        public virtual List<TEntity> GetAll()
        {
            var criteriaQuery = Session.CreateCriteria(typeof(TEntity));
            return (List<TEntity>)criteriaQuery.List<TEntity>();
        }

        public List<TEntity> GetByIds(List<TId> ids)
        {
            return Session.CreateCriteria<TEntity>()
                .Add(Restrictions.In("Id", ids))
                .List<TEntity>()
                .ToList();
        }

        public void Flush()
        {
            Session.Flush();
        }

        public void Clear()
        {
            Session.Clear();
        }
    }
}

