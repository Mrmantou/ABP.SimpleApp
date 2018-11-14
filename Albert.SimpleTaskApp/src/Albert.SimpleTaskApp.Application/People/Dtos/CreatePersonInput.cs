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

        [StringLength(SimpleTaskAppConsts.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        //[EmailAddress]
        public string Email { get; set; }

        [StringLength(SimpleTaskAppConsts.MaxAddressLength)]
        public string Address { get; set; }
    }
}
