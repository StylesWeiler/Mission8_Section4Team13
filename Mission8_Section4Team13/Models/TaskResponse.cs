using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Mission8_Section4Team13.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int taskId { get; set; }

        [Required]
        public string task { get; set; }

        public DateTime dueDate { get; set; }

        [Required]
        public int quadrant { get; set; }

        public bool completed { get; set; }

        // Build the foreign key relationship
        [Required]
        public int categoryId { get; set; } // foreign key
        public Category category { get; set; } // paired with an instance of the Category type creates a connection between the two tables
    }
}


