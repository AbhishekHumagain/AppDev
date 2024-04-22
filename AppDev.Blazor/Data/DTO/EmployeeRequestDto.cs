namespace AppDev.Blazor.Data.DTO;

public class EmployeeRequestDto
{
    public DateTime JoinDate { get; set; }
    public string Designation { get; set; }
    public float Salary { get; set; }
    public Guid DepartmentId { get; set; }
}