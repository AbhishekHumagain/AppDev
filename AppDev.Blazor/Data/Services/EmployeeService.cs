using AppDev.Blazor.Data.DTO;
using AppDev.Blazor.Data.Helper;
using Newtonsoft.Json;

namespace AppDev.Blazor.Data.Services;

public class EmployeeService
{
    private readonly HttpClient _httpClient;
    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeData>?> GetEmployeeAsync()
    {
        var response = await _httpClient.AuthGetAsync("https://localhost:7190/api/employee/all-employee");
        var result = response.Content.ReadAsStringAsync().Result;
        var rr = JsonConvert.DeserializeObject<List<EmployeeData>>(result);
        return rr;
    }
}