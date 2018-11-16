using Abp.AspNetCore.Mvc.ViewComponents;

namespace EventCloud.Web.Views
{
    public abstract class EventCloudViewComponent : AbpViewComponent
    {
        protected EventCloudViewComponent()
        {
            LocalizationSourceName = EventCloudConsts.LocalizationSourceName;
        }
    }
}
