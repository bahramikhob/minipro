using AutomapperSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperSample.ConfigProfile
{
    public class PersonProfile:AutoMapper.Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonViewModel,Person>();//.ReverseMap();
            CreateMap<Person, PersonViewModel>()
                .ForMember(p=>p.FullName,op=>op.MapFrom(s=>s.Name+" "+s.Family));//=>fullname=name+" "+family
        }
    }
}
