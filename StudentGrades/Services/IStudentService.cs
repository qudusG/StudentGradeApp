using StudentGrades.Models;

namespace StudentGrades.Services
{
    public interface IStudentService
    {
        Task AssignGradeAsync(int studentId, Grade grade);
        Task<Student?> GetStudentByIdAsync(int id);
        Task<List<Student>> GetStudentsAsync();
    }
}