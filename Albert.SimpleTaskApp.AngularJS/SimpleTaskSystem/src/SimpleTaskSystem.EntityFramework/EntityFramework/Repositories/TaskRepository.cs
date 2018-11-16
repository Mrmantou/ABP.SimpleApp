using Abp.Collections.Extensions;
using Abp.EntityFramework;
using Abp.Linq.Extensions;
using SimpleTaskSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    public class TaskRepository : SimpleTaskSystemRepositoryBase<Task, long>, ITaskRepository

    {
        public TaskRepository(IDbContextProvider<SimpleTaskSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            //In repository methods, we do not deal with create/dispose DB connections, DbContexes and transactions. ABP handles it.

            var query = GetAll();
            //GetAll() returns IQueryable<T>, so we can query over it.
            //var query = Context.Tasks.AsQueryable(); //Alternatively, we can directly use EF's DbContext object.
            //var query = Table.AsQueryable(); //Another alternative: We can directly use 'Table' property instead of 'Context.Tasks', they are identical.

            //Add some Where conditions...


            return query
                .WhereIf(assignedPersonId.HasValue, t => t.AssignedPersonId == assignedPersonId.Value)
                .WhereIf(state.HasValue, t => t.State == state)
                .OrderByDescending(t => t.CreationTime)
                .Include(t => t.AssignedPerson)
                .ToList();
        }
    }
}
