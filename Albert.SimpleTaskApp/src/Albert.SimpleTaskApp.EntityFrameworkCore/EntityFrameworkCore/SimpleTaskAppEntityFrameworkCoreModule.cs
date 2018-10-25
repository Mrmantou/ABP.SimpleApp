using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Albert.SimpleTaskApp.EntityFrameworkCore.Seed;

namespace Albert.SimpleTaskApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(SimpleTaskAppCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class SimpleTaskAppEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppEntityFrameworkCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            SeedHelper.SeedDb(IocManager);
        }
    }
}