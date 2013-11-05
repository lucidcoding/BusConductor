using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BusConductor.UI.ViewModels
{
    public class TaskRaiseEditViewModel
    {
        public Guid? TaskId { get; set; }
        //[Required]
        public string Description { get; set; }

        public SelectList Assignees { get; set; }

        public Guid? AssignedToId { get; set; }

        public SelectList TaskTypes { get; set; }

        public Guid? TypeId { get; set; }

        public string SubmitButtonTitle { get; set; }
        public string SubmitButtonAction { get; set; }
    }
}