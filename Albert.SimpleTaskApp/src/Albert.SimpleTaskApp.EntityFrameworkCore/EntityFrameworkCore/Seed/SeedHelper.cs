using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Albert.SimpleTaskApp.EntityFrameworkCore.Seed.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Albert.SimpleTaskApp.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedDb(IIocResolver iocResolver)
        {
            WithDbContext<SimpleTaskAppDbContext>(iocResolver, SeedDb);
        }

        private static void SeedDb(SimpleTaskAppDbContext context)
        {
            new InitialTask(context).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction) where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>();

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
