using Albert.SimpleTaskApp.People;
using Albert.SimpleTaskApp.People.Dtos;
using Albert.SimpleTaskApp.Web.Models.People;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.Web.Controllers
{
    public class PeopleController : SimpleTaskAppControllerBase
    {
        private readonly IPersonAppService personAppService;

        public PeopleController(IPersonAppService personAppService)
        {
            this.personAppService = personAppService;
        }

        public async Task<IActionResult> Index(GetAllPeopleInput input)
        {
            var output = await personAppService.GetAll(input);

            var model = new PeopleIndexViewModel(output.Items);

            return View(model);
        }

        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }
    }
}