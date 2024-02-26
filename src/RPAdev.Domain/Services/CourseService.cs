using RPAdev.Domain.Interfaces;
using RPAdev.Domain.Models;

namespace RPAdev.Domain.Services;

public class CourseService : ICourseService
{
    private readonly ISearchCourseFactory _searchCourseFactory;
    private readonly ICourseRepository _courseRep;

    public CourseService(ISearchCourseFactory searchCourseFactory, ICourseRepository courseRep)
    {
        _searchCourseFactory = searchCourseFactory;
        _courseRep = courseRep;
    }

    public async Task<IEnumerable<Course>> GetAll()
    {
        return await _courseRep.GetAll();
    }

    public async Task<Response> SearchCourseInAlura(string courseName)
    {
        return await _searchCourseFactory.Search(courseName);
    }

}
