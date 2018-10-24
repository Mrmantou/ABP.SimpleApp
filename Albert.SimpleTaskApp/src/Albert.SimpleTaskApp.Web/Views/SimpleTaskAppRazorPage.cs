using Abp.AspNetCore.Mvc.Views;

namespace Albert.SimpleTaskApp.Web.Views
{
    public abstract class SimpleTaskAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SimpleTaskAppRazorPage()
        {
            LocalizationSourceName = SimpleTaskAppConsts.LocalizationSourceName;
        }
    }
}
