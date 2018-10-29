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

        public Person() { }

        public Person(string name)
        {
            Name = name;
        }
    }
}
