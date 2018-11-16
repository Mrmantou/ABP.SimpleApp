using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Albert.SimpleTaskApp.People
{
    [Table("AppPersons")]
    public class Person : AuditedEntity<Guid>
    {
        [Required]
        [StringLength(SimpleTaskAppConsts.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(SimpleTaskAppConsts.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(SimpleTaskAppConsts.MaxAddressLength)]
        public string Address { get; set; }

        public Person() { }

        public Person(string name)
        {
            Name = name;
        }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
    }
}
