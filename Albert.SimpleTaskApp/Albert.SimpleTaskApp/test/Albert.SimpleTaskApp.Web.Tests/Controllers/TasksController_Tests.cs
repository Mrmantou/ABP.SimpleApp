using Albert.SimpleTaskApp.Tasks;
using Albert.SimpleTaskApp.Web.Controllers;
using AngleSharp.Parser.Html;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Albert.SimpleTaskApp.Web.Tests.Controllers
{
    public class TasksController_Tests : SimpleTaskAppWebTestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Tasks_By_State()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<TasksController>(nameof(TasksController.Index), new
                {
                    State = TaskState.Open
                }));

            //Assert
            response.ShouldNotBeNullOrWhiteSpace();

            //get tasks from database
            var tasksInDatabase = await UsingDbContextAsync(async dbContext =>
            {
                return await dbContext.Tasks
                    .Where(t => t.State == TaskState.Open)
                    .ToListAsync();
            });

            //parse html response to check if tasks in the database are returned
            var document = new HtmlParser().Parse(response);
            var listItems = document.QuerySelectorAll("#TaskList li");

            //check task count
            listItems.Length.ShouldBe(tasksInDatabase.Count);

            //check if returned list items are same those in the database
            foreach (var item in listItems)
            {
                var header = item.QuerySelector(".list-group-item-heading");
                var taskTitle = header.InnerHtml.Trim();
                tasksInDatabase.Any(t => t.Title == taskTitle).ShouldBeTrue();
            }
        }
    }
}
