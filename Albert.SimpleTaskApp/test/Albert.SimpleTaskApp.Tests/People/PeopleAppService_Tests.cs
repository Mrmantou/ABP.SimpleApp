using Albert.SimpleTaskApp.People;
using Albert.SimpleTaskApp.People.Dtos;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Albert.SimpleTaskApp.Tests.People
{
    public class PeopleAppService_Tests : SimpleTaskAppTestBase
    {
        private readonly IPersonAppService personAppService;

        public PeopleAppService_Tests()
        {
            personAppService = Resolve<IPersonAppService>();
        }

        [Fact]
        public async Task Should_Create_New_Person_With_Name()
        {
            await personAppService.Create(new CreatePersonInput
            {
                Name = "albert"
            });

            UsingDbContext(context =>
            {
                var person1 = context.People.FirstOrDefault(p => p.Name == "albert");
                person1.ShouldNotBeNull();
            });
        }
    }
}
