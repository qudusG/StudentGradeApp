using Microsoft.EntityFrameworkCore;
using StudentGrades.Models;

namespace StudentGrades;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}