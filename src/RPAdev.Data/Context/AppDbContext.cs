using Microsoft.EntityFrameworkCore;
using RPAdev.Domain.Models;

namespace RPAdev.Data.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

	public DbSet<Course> Courses { get; set; }


}
