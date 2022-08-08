https://automapper.org/
https://www.nuget.org/packages/automapper/

1-Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

	Install-Package AutoMapper

--------------------------------------------------

2-
public class PersonProfile:AutoMapper.Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonViewModel,Person>();//.ReverseMap();
            CreateMap<Person, PersonViewModel>()
                .ForMember(p=>p.FullName,op=>op.MapFrom(s=>s.Name+" "+s.Family));//=>fullname=name+" "+family
        }
    }

3-services.AddAutoMapper(typeof(Startup));

Note: AutoMapper will scan our application and
look for classes that inherit from the Profile
class and load their mapping configurations.


4-
        private readonly IMapper mapper;
        public HomeController(IMapper mapper)
        {
            this.mapper = mapper;
        }


5-
        public IActionResult personToPersonViewModel()
        {
            Person person = new Person() { ID = 1, Name = "Ali", Family = "Rezayee", Age = 30 };
            var vm = mapper.Map<PersonViewModel>(source: person);
            var result = vm.FullName;//note
            return View();
        }



