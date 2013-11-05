using System;

namespace BusConductor.UI.ViewModels
{
    public class TaskIndexTaskViewModel
    {
        public Guid TaskId { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Type { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string RagStatus { get; set; } 
    }
}