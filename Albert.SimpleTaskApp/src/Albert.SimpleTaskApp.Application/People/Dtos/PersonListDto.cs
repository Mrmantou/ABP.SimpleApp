using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.SimpleTaskApp.People.Dtos
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int? Age { get; set; }

        public char? Gender { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}
