namespace AppDev.Application.DTOs
{
    public class EmployeeRequestDTO
    {
        public DateTime JoinDate { get; set; }
        public string Designation { get; set; }
        public float Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
