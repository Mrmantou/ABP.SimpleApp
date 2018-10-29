using Albert.SimpleTaskApp.Tasks;
using Albert.SimpleTaskApp.Tasks.Dtos;
using Shouldly;
using System.Linq;
using Xunit;

namespace Albert.SimpleTaskApp.Tests.Tasks
{
    public class TaskAppService_Tests : SimpleTaskAppTestBase
    {
        private readonly ITaskAppService taskAppService;

        public TaskAppService_Tests()
        {
            taskAppService = Resolve<ITaskAppService>();
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_All_Tasks()
        {
            //Act
            var output = await taskAppService.GetAll(new GetAllTasksInput());

            //Assert
            output.Items.Count.ShouldBe(2);
            output.Items.Count(t => t.AssignedPersonId.HasValue).ShouldBe(1);
            output.Items.Count(t => t.AssignedPersonName != null).ShouldBe(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Filtered_Tasks()
        {
            //Act
            var output = await taskAppService.GetAll(
                new GetAllTasksInput() { State = TaskState.Open });

            //Assert
            output.Items.ShouldAllBe(t => t.State == TaskState.Open);
        }
    }
}
