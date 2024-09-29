using System.ComponentModel.DataAnnotations;

namespace TaskManagementUI.Models
{
    public class TaskTable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The task title is mandatory.")]
        public string Title { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "The project is mandatory.")]
        public int ProjectId { get; set; }
    }
}
