using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MakePassService.Methods;

public static class HttpMethods
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://localhost:7297/api/")
    };

    public static async Task<T?> HttpGetAsync<T>(string destination)
    {
        var response = await HttpClient.GetAsync(destination);
        var request = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T>(request);
    }

    public static async Task<T?> HttpPostAsync<T>(string destination, T content)
    {
        var response = await HttpClient.PostAsJsonAsync(destination, content);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<T>();
        return default;
    }
}