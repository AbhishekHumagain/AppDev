namespace AppDev.Application.DTOs;

public class ResponseDTO
{
    public string? Status { get; set; }
    public string? Message { get; set; }
}


public class ErrorMessageResponse
{
    public string? Message { get; set; }
    public string? ContentType { get; set; }
    public int StatusCode { get; set; }
}