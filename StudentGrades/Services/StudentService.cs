using StudentGrades.Models;
using StudentGrades;
using Microsoft.EntityFrameworkCore;

namespace StudentGrades.Services;

public class StudentService(ApplicationDbContext context) : IStudentService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _context.Students.Include(s => s.Grades).ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _context.Students.Include(s => s.Grades).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AssignGradeAsync(int studentId, Grade grade)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student == null) throw new KeyNotFoundException("Student not found");

        student.Grades.Add(grade);
        await _context.SaveChangesAsync();
    }
}