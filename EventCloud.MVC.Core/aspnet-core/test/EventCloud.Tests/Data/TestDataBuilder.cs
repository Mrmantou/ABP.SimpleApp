using Abp.Timing;
using EventCloud.EntityFrameworkCore;
using EventCloud.Events;
using EventCloud.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventCloud.Tests.Data
{
    public class TestDataBuilder
    {
        public const string TestEventTitle = "Test event title";

        private readonly EventCloudDbContext context;

        public TestDataBuilder(EventCloudDbContext context)
        {
            this.context = context;
        }

        public void Build()
        {
            CreateTestEvent();
        }

        private void CreateTestEvent()
        {
            var defaultTenant = context.Tenants.Single(t => t.TenancyName == Tenant.DefaultTenantName);
            context.Events.Add(Event.Create(defaultTenant.Id, TestEventTitle, Clock.Now.AddDays(1)));
            context.SaveChanges();
        }
    }
}
