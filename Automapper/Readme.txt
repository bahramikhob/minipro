https://automapper.org/
https://www.nuget.org/packages/automapper/

Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

	Install-Package AutoMapper

--------------------------------------------------

services.AddAutoMapper(typeof(Startup));

Note: AutoMapper will scan our application and
look for classes that inherit from the Profile
class and load their mapping configurations.
