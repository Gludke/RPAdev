using DevIO.Data.Repository;
using RPAdev.Data.Context;
using RPAdev.Domain.Interfaces;
using RPAdev.Domain.Models;

namespace RPAdev.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context) { }
    }
}
