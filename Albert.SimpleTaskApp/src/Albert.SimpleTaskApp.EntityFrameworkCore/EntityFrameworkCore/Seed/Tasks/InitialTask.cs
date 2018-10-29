using Albert.SimpleTaskApp.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albert.SimpleTaskApp.EntityFrameworkCore.Seed.Tasks
{
    public class InitialTask
    {
        private readonly SimpleTaskAppDbContext context;

        public InitialTask(SimpleTaskAppDbContext context)
        {
            this.context = context;
        }

        public void Create()
        {
            CreateTask();
        }

        private void CreateTask()
        {
            var neo = context.People.FirstOrDefault();
            if (context.Tasks.Any())
            {
                if (context.Tasks.All(t => t.AssignedPersonId == null))
                {
                    context.Tasks.Last().AssignedPersonId = neo.Id;
                    context.SaveChanges();
                }
                
                return;
            }

            context.AddRange(
                new Task { Title = "Chinese", Description = "recite the text" },
                new Task { Title = "Math", Description = "do all the homework" },
                new Task { Title = "English", Description = "recite new word", AssignedPersonId = neo?.Id }
                );

            context.SaveChanges();
        }
    }
}
