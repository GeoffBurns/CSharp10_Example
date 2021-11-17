using System;
using System.Text.Json;

namespace MyFinance.Extensions;

public static class FetchExtensions
{

    static readonly HttpClient client = new();

    public static async Task<T?> Fetch<T>(this string requestUri)
    {
        return await JsonSerializer.DeserializeAsync<T>
                   (
                   await client.GetStreamAsync(requestUri),
                   new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                   );
    }
}

