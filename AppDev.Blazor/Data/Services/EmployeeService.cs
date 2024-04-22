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
    
    public async Task<int> CountEmployee()
    {
        var response = await _httpClient.AuthGetAsync("https://localhost:7190/api/employee/all-employee");
        var result = response.Content.ReadAsStringAsync().Result;
        var rr = JsonConvert.DeserializeObject<List<EmployeeData>>(result);
        return rr.Count;
    }
    
    public async Task<string> PostEmployeeAsync(EmployeeRequestDto requestDto)
    {
        var response = await _httpClient.AuthPostAsJsonAsync("https://localhost:7190/api/employee/add-employee", requestDto);
        if (response.IsSuccessStatusCode)
        {
            return "Employee Added";
        }
        return "Employee Not Added";
    }
}