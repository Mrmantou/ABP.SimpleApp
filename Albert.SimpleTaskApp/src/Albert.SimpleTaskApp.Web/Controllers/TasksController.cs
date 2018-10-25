using Albert.SimpleTaskApp.Tasks;
using Albert.SimpleTaskApp.Tasks.Dtos;
using Albert.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            this.taskAppService = taskAppService;
        }

        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await taskAppService.GetAll(input);

            var model = new IndexViewModel(output.Items);

            return View(model);
        }
    }
}