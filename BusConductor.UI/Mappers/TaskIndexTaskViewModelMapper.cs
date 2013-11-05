using System.Collections.Generic;
using BusConductor.Domain.Entities;
using BusConductor.UI.ViewModels;

namespace BusConductor.UI.Mappers
{
    public class TaskIndexTaskViewModelMapper
    {
        public static IList<TaskIndexTaskViewModel> MapToViewModel(IList<Task> tasks)
        {
            var viewModel = new List<TaskIndexTaskViewModel>();

            foreach (var task in tasks)
            {
                viewModel.Add(new TaskIndexTaskViewModel
                              {
                                  TaskId = task.Id.Value,
                                  AssignedTo = task.AssignedTo != null ? task.AssignedTo.Username : "",
                                  Description = task.Description,
                                  DueDate = task.DueDate,
                                  RagStatus = task.RagStatus.ToString(),
                                  Status = task.Status.ToString(),
                                  Type = task.Type != null ? task.Type.Description : ""
                              });
            }

            return viewModel;
        }
    }
}