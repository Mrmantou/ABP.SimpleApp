using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Albert.SimpleTaskApp.People.Dtos
{
    [AutoMapTo(typeof(Person))]
    public class CreatePersonInput
    {
        [Required]
        [StringLength(SimpleTaskAppConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
