namespace StudentGrades.Models;

public class Grade
{
    public int Id { get; set; }
    public Subject Subject { get; set; }
    public double Score { get; set; }
}