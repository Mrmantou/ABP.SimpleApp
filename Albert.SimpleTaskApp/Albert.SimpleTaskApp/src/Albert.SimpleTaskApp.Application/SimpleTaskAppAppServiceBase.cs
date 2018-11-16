using Abp.Application.Services;

namespace Albert.SimpleTaskApp
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class SimpleTaskAppAppServiceBase : ApplicationService
    {
        protected SimpleTaskAppAppServiceBase()
        {
            LocalizationSourceName = SimpleTaskAppConsts.LocalizationSourceName;
        }
    }
}