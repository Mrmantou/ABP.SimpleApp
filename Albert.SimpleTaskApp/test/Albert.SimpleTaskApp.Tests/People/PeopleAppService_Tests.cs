using Abp.Runtime.Validation;
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
                Name = "li"
            });

            UsingDbContext(context =>
            {
                var person1 = context.People.FirstOrDefault(p => p.Name == "li");
                person1.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task Should_Create_New_Person_Without_Name()
        {
            await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await personAppService.Create(new CreatePersonInput
                {
                    Name = null
                });
            });
        }

        [Fact]
        public async Task Should_Get_All_People()
        {
            var output = await personAppService.GetAll(new GetAllPeopleInput());

            output.Items.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Get_Filtered_People()
        {
            var output = await personAppService.GetAll(new GetAllPeopleInput() { Name = "Athy" });

            output.Items.Count.ShouldBe(1);
            output.Items.ShouldAllBe(p => p.Name == "Athy");
        }
    }
}
