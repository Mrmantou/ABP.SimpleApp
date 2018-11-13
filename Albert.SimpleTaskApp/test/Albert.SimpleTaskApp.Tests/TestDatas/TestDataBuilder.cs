using Albert.SimpleTaskApp.EntityFrameworkCore;
using Albert.SimpleTaskApp.People;
using Albert.SimpleTaskApp.Tasks;

namespace Albert.SimpleTaskApp.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly SimpleTaskAppDbContext _context;

        public TestDataBuilder(SimpleTaskAppDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
            var neo = new Person("Neo");
            var athy = new Person("Athy");
            _context.People.Add(neo);
            _context.People.Add(athy);
            _context.SaveChanges();

            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality.", neo.Id),
                new Task("Clean your room") { State = TaskState.Completed }
                );
        }
    }
}