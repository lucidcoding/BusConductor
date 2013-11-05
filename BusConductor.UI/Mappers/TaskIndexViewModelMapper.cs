using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusConductor.Domain.Entities;
using BusConductor.Domain.Enumerations;
using BusConductor.UI.Extensions;
using BusConductor.UI.ViewModels;

namespace BusConductor.UI.Mappers
{
    public class TaskIndexViewModelMapper
    {
        public static TaskIndexViewModel MapToViewModel(
            IList<User> users,
            Guid? userId,
            IList<TaskType> taskTypes,
            Guid? taskTypeId,
            DateTime? dueDateFrom,
            DateTime? dueDateTo,
            TaskStatus? taskStatus,
            IList<Task> tasks)
        {
            var viewModel = new TaskIndexViewModel();
            viewModel.Users = new SelectList(users, "Id", "Username", userId).AddDefaultOption();
            viewModel.TaskTypes = new SelectList(taskTypes, "Id", "Description", taskTypeId).AddDefaultOption();
            viewModel.DueDateFrom = dueDateFrom;
            viewModel.DueDateTo = dueDateTo;
            viewModel.TaskStatuses = new TaskStatus().ToSelectList(taskStatus).AddDefaultOption();
            viewModel.Tasks = TaskIndexTaskViewModelMapper.MapToViewModel(tasks);
            return viewModel;
        }
    }
}