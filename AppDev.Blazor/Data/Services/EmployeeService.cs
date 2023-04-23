using AppDev.Blazor.Data.DTO;
using Newtonsoft.Json;

namespace AppDev.Blazor.Data.Services;

public class EmployeeService
{
    private readonly HttpClient _httpClient;
    private string baseUrl = "https://localhost:7190/";
    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeData>?> GetEmployeeAsync()
    {
        var response =  await _httpClient.GetAsync("https://localhost:7190/api/employee/all-employee");
        
        var result = response.Content.ReadAsStringAsync().Result;
        var rr = JsonConvert.DeserializeObject<List<EmployeeData>>(result);
        return rr;
    }
}