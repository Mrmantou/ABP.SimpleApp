using Abp.Application.Services.Dto;
using Albert.SimpleTaskApp.People.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.People
{
    public interface IPersonAppService
    {
        Task<ListResultDto<ComboboxItemDto>> GetPeopleComboboxItems();

        Task Create(CreatePersonInput input);
    }
}
