using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Albert.SimpleTaskApp.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
    }
}
