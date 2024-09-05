using CleanApp.API.Filters;

namespace CleanApp.API.Extensions
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddControllersWithFiltersExt(this IServiceCollection services)
        {
            services.AddScoped(typeof(NotFoundFilter<,>));


            services.AddControllers(options =>
            {
                options.Filters.Add<FluentValidationFilter>();
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });

            return services;
        }
    }
}