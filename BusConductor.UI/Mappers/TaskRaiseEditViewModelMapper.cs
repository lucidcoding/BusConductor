using System.Collections.Generic;
using System.Web.Mvc;
using BusConductor.Domain.Entities;
using BusConductor.UI.ViewModels;

namespace BusConductor.UI.Mappers
{
    public class TaskRaiseEditViewModelMapper
    {
        public static TaskRaiseEditViewModel MapToViewModel(IEnumerable<User> users, IEnumerable<TaskType> taskTypes)
        {
            var viewModel = new TaskRaiseEditViewModel();
            viewModel.Assignees = new SelectList(users, "Id", "Username");
            viewModel.TaskTypes = new SelectList(taskTypes, "Id", "Description");
            viewModel.SubmitButtonTitle = "Create";
            return viewModel;
        }

        public static TaskRaiseEditViewModel MapToViewModel(Task task, IEnumerable<User> users, IEnumerable<TaskType> taskTypes)
        {
            var viewModel = new TaskRaiseEditViewModel();
            viewModel.Assignees = new SelectList(users, "Id", "Username");
            viewModel.TaskTypes = new SelectList(taskTypes, "Id", "Description");
            viewModel.TaskId = task.Id;
            viewModel.Description = task.Description;
            viewModel.AssignedToId = task.AssignedTo != null ? task.AssignedTo.Id : null;
            viewModel.TypeId = task.Type != null ? task.Type.Id : null;
            viewModel.SubmitButtonTitle = "Update";
            return viewModel;
        }

        public static TaskRaiseEditViewModel MapToViewModel(TaskRaiseEditViewModel viewModel, IEnumerable<User> users, IEnumerable<TaskType> taskTypes)
        {
            viewModel.Assignees = new SelectList(users, "Id", "Username");
            viewModel.TaskTypes = new SelectList(taskTypes, "Id", "Description");
            return viewModel;
        }
    }
}