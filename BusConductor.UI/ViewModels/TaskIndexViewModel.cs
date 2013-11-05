using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusConductor.Domain.Enumerations;

namespace BusConductor.UI.ViewModels
{
    public class TaskIndexViewModel
    {
        public SelectList Users { get; set; }
        public Guid? UserId { get; set; }
        public SelectList TaskTypes { get; set; }
        public Guid? TaskTypeId { get; set; }
        public DateTime? DueDateFrom { get; set; }
        public DateTime? DueDateTo { get; set; }
        public TaskStatus? TaskStatus { get; set; }
        public SelectList TaskStatuses { get; set; }
        public IList<TaskIndexTaskViewModel> Tasks { get; set; }
    }
}