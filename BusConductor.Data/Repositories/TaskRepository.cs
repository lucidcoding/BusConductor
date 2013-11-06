using System;
using System.Collections.Generic;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class TaskRepository : Repository<Task, Guid>, ITaskRepository
    {
        public TaskRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public IList<Task> Search(
            Guid? assignedToId,
            Guid? taskTypeId,
            DateTime? dueDateFrom,
            DateTime? dueDateTo,
            TaskStatus? taskStatus,
            bool? deleted
        )
        {
            //var criteria = Session.CreateCriteria<Task>();

            //if(assignedToId.HasValue)
            //{
            //    criteria.Add(Restrictions.Eq("AssignedTo.Id", assignedToId.Value));
            //}

            //if (taskTypeId.HasValue)
            //{
            //    criteria.Add(Restrictions.Eq("Type.Id", taskTypeId.Value));
            //}

            //if (dueDateFrom.HasValue)
            //{
            //    criteria.Add(Restrictions.Ge("DueDate", dueDateFrom.Value));
            //}

            //if (dueDateTo.HasValue)
            //{
            //    criteria.Add(Restrictions.Le("DueDate", dueDateTo.Value.AddDays(1)));
            //}

            //if(taskStatus.HasValue)
            //{
            //    criteria.Add(Restrictions.Eq("Status", taskStatus.Value));
            //}

            //if(deleted.HasValue)
            //{
            //    criteria.Add(Restrictions.Eq("Deleted", deleted.Value));
            //}

            //return criteria.List<Task>();
            //todo: fix this.
            return null;
        }
    }
}
