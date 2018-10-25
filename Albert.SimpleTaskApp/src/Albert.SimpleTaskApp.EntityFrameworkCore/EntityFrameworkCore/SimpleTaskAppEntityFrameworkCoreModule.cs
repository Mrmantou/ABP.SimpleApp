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
        /// <summary>
        /// 单元测试中跳过向数据库中添加初始化数据，测试数据在单元测试中由TestDataBuilder添加
        /// </summary>
        public bool SkipDbSeed { get; set; }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppEntityFrameworkCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedDb(IocManager);
            }
        }
    }
}