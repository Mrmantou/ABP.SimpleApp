using Abp.Modules;
using Abp.Reflection.Extensions;
using Albert.SimpleTaskApp.Localization;

namespace Albert.SimpleTaskApp
{
    public class SimpleTaskAppCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            SimpleTaskAppLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppCoreModule).GetAssembly());
        }
    }
}