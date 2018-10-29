using Albert.SimpleTaskApp.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albert.SimpleTaskApp.EntityFrameworkCore.Seed.People
{
   public class InitialPerson
    {
        private readonly SimpleTaskAppDbContext dbContext;

        public InitialPerson(SimpleTaskAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create()
        {
            CreatePeople();
        }

        private void CreatePeople()
        {
            if(dbContext.People.Any())
            {
                return;
            }
            
            dbContext.Add(new Person("Neo"));
            dbContext.SaveChanges();
        }
    }
}
