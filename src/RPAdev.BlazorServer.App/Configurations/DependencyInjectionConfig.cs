using RPAdev.Data.Repositories;
using RPAdev.Domain.Factorys;
using RPAdev.Domain.Interfaces;
using RPAdev.Domain.Services;

namespace RPAdev.BlazorServer.App.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection service)
    {
        //service.AddScoped<AppDbContext>();
        service.AddScoped<ISearchCourseFactory, SearchCourseFactory>();
        
        service.AddScoped<ICourseRepository, CourseRepository>();

        service.AddScoped<ICourseService, CourseService>();

        return service;
    }
}
