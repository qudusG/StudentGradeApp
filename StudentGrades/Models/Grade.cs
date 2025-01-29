using System.ComponentModel.DataAnnotations;

namespace StudentGrades.Models;

public class Grade
{
    public int Id { get; set; }
    public Subject Subject { get; set; }

    [Range(0, 100, ErrorMessage = "Score must be between 0 and 100.")]
    public double Score { get; set; }
}
