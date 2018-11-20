using EventCloud.Events;
using EventCloud.Events.Dtos;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventCloud.Tests.Events
{
    public class EventAppService_Tests : EventCloudTestBase
    {
        private readonly IEventAppService eventAppService;

        public EventAppService_Tests()
        {
            eventAppService = Resolve<IEventAppService>();
        }

        [Fact]
        public async Task Should_Get_Test_Events()
        {
            var output = await eventAppService.GetListAsync(new GetEventListInput());

            output.Items.Count.ShouldBe(1);
        }
    }
}
