using Abp.Application.Services.Dto;
using Albert.SimpleTaskApp.People;
using Albert.SimpleTaskApp.Tasks;
using Albert.SimpleTaskApp.Tasks.Dtos;
using Albert.SimpleTaskApp.Web.Models.People;
using Albert.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService taskAppService;
        private readonly IPersonAppService peopleAppService;

        public TasksController(ITaskAppService taskAppService, IPersonAppService peopleAppService)
        {
            this.taskAppService = taskAppService;
            this.peopleAppService = peopleAppService;
        }

        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await taskAppService.GetAll(input);

            var model = new IndexViewModel(output.Items)
            {
                SelectedTaskState = input.State
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var peopleSelectListItems = (await peopleAppService.GetPeopleComboboxItems())
                .Items
                .Select(p => p.ToSelectListItem())
                .ToList();

            peopleSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View(new CreateTaskViewModel(peopleSelectListItems));
        }
    }
}