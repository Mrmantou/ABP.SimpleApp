using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using EventCloud.Controllers;

namespace EventCloud.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : EventCloudControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
