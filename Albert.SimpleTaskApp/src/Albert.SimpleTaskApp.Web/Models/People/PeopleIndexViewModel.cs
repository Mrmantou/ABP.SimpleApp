using Albert.SimpleTaskApp.People;
using Albert.SimpleTaskApp.People.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albert.SimpleTaskApp.Web.Models.People
{
    public class PeopleIndexViewModel
    {
        public IReadOnlyList<PersonListDto> People { get; set; }

        public PeopleIndexViewModel(IReadOnlyList<PersonListDto> people)
        {
            People = people;
        }

        public string GetPersonGender(Genter? gender)
        {
            switch (gender)
            {
                case Genter.Male:
                    return "fa fa-mars";
                case Genter.Female:
                    return "fa fa-venus";
                default:
                    return "fa fa-genderless";
            }
        }
    }
}
