using RPAdev.Domain.Models;

namespace RPAdev.Domain.Interfaces;

public interface ICourseService
{
    public Task<IEnumerable<Course>> GetAll();
    public Task<Response> SearchCourseInAlura(string courseName);
}