using System.Text;
using System.Text.Json;

namespace AppDev.Blazor.Data.Helper;

public static class HttpClientExtension
{
    private static HttpContent Serialize(object data) => new StringContent(
        JsonSerializer.Serialize(data, new JsonSerializerOptions(JsonSerializerDefaults.Web)), Encoding.UTF8,
        "application/json");


    public static Task<HttpResponseMessage> AuthGetAsync(this HttpClient httpClient, string requestUri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
        return httpClient.SendAsync(request);
    }
    
    public static Task<HttpResponseMessage> AuthPostAsync(this HttpClient httpClient, string requestUri, HttpContent? content)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
        request.Content = content;
        return httpClient.SendAsync(request);
    }


    public static Task<HttpResponseMessage> AuthPostAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data) where T : class
    {
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
        request.Content = Serialize(data);
        return httpClient.SendAsync(request);
    }

}
