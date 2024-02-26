namespace RPAdev.Domain.Interfaces;

public interface ISearchCourseFactory
{
    public Task<Response> Search(string search);
}
