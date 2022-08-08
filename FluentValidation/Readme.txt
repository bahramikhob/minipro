Website:
https://fluentvalidation.net/

Github:
https://github.com/FluentValidation/FluentValidation

Nuget:
https://www.nuget.org/packages/FluentValidation/

--------------------------------------------------

1-Install-Package FluentValidation.AspNetCore

	FluentValidation
	FluentValidation.DependencyInjectionExtensions

2-
			services.AddControllers()
				.AddFluentValidation(current =>
				{
					current.RegisterValidatorsFromAssemblyContaining<Startup>();

					current.LocalizationEnabled = true; // Default: [true]
					current.AutomaticValidationEnabled = true; // Default: [true]
					current.ImplicitlyValidateChildProperties = false; // Default: [false]
					current.ImplicitlyValidateRootCollectionElements = false; // Default: [false]
					current.RunDefaultMvcValidationAfterFluentValidationExecutes = false; // Default: [true]
				});
