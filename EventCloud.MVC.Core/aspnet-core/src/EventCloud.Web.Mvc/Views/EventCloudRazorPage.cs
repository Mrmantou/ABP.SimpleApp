using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace EventCloud.Web.Views
{
    public abstract class EventCloudRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected EventCloudRazorPage()
        {
            LocalizationSourceName = EventCloudConsts.LocalizationSourceName;
        }
    }
}
