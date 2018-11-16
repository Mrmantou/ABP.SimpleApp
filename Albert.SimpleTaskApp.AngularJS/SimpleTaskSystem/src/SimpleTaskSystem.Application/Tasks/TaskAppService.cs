using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using SimpleTaskSystem.People;
using SimpleTaskSystem.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Tasks
{
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        //These members set in constructor using constructor injection.

        private readonly ITaskRepository taskRepository;
        private readonly IRepository<Person> personRepository;

        public TaskAppService(ITaskRepository taskRepository, IRepository<Person> personRepository)
        {
            this.taskRepository = taskRepository;
            this.personRepository = personRepository;
        }


        public void CreateTask(CreateTaskInput input)
        {
            Logger.Info("Creating a task for input: " + input);

            var task = new Task { Description = input.Description };

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPersonId = input.AssignedPersonId.Value;
            }

            taskRepository.Insert(task);
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            var tasks = taskRepository.GetAllWithPeople(input.AssignedPersonId, input.State);

            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(tasks)
            };
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            Logger.Info("Updating a task for input: " + input);

            var task = taskRepository.Get(input.TaskId);

            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = personRepository.Load(input.AssignedPersonId.Value);
            }

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }
    }
}
