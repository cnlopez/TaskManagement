using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskTable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }

        // Foreign key
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
