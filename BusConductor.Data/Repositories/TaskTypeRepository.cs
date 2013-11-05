using System;
using NHibernate;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class TaskTypeRepository : Repository<TaskType, Guid>, ITaskTypeRepository
    {
        public TaskTypeRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }
    }
}
