using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using EventCloud.Controllers;

namespace EventCloud.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : EventCloudControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
