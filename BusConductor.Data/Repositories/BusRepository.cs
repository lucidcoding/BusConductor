using System;
using NHibernate;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class BusRepository : Repository<Bus, Guid>, IBusRepository
    {
        public BusRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }
    }
}
