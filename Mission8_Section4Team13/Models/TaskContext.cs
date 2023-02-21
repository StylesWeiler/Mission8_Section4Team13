using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Section4Team13.Models
{
    public class TaskContext: DbContext // inheritance to make it a context file
    {
        // constructor (no return)
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) // inherits from the base DbContextOptions options
        {

        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb) // overrides the default conditions for OnModelCreating
        {

            mb.Entity<Category>().HasData(

                new Category { categoryId = 1, categoryName = "Home" },
                new Category { categoryId = 2, categoryName = "School" },
                new Category { categoryId = 3, categoryName = "Work" },
                new Category { categoryId = 4, categoryName = "Church" }

           );

        }

        // public available to any class in the program
        // private only available within that particular class
        // protected not available to outside classes, but anything within the chain of inheritance can access it
    }
}

