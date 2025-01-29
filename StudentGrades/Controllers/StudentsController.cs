using Microsoft.AspNetCore.Mvc;
using StudentGrades.Models;
using StudentGrades.Services;

namespace StudentGrades.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IStudentService service) : ControllerBase
{
    private readonly IStudentService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var students = await _service.GetStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _service.GetStudentByIdAsync(id);
        if (student == null) return NotFound();

        return Ok(student);
    }

    [HttpPost("{id}/assign-grade")]
    public async Task<IActionResult> AssignGrade(int id, [FromBody] Grade grade)
    {
        await _service.AssignGradeAsync(id, grade);
        return Ok();
    }
}