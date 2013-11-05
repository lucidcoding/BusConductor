using System;
using System.Collections.Generic;
using BusConductor.Domain.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;

namespace BusConductor.Domain.RepositoryContracts
{
    public interface ITaskRepository : IRepository<Task, Guid>
    {
        IList<Task> Search(
            Guid? assignedToId,
            Guid? taskTypeId,
            DateTime? dueDateFrom,
            DateTime? dueDateTo,
            TaskStatus? taskStatus,
            bool? deleted
            );
    }
}
