
using Microsoft.EntityFrameworkCore;
using StudentGrades.Models;
using StudentGrades.Services;

namespace StudentGrades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("SchoolDb"));
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddControllers();

            var app = builder.Build();
            SeedData(app.Services);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.Run();
        }

        static void SeedData(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Students.Any())
                context.Students.AddRange(new[]
                {
                    new Student { Id = 1, Name = "Alice Johnson" },
                    new Student { Id = 2, Name = "Bob Smith" }
                });
                context.SaveChanges();
            }
    }
}
