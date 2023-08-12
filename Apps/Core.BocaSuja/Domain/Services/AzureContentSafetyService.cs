using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Services.Interfaces;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.Domain.Services;

public sealed class AzureContentSafetyService
{
    public static async Task<ContentSafetyResult> CallAPI(
        string text,
        string endpoint,
        string subscriptionKey,
        string version
    )
    {
        string url = $"{endpoint}/contentsafety/text:analyze?api-version={version}";

        HttpClient client = new();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

        string requestBody =
            $@"{{
            ""text"": ""{text}"",
            ""categories"": [
            ""Hate"", ""Sexual"", ""SelfHarm"", ""Violence""
            ]
        }}";

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result =
                    JsonConvert.DeserializeObject<ContentSafetyResult>(responseContent)
                    ?? throw new Exception("Erro ao chamar API de validação de texto.");
                return result;
            }
            else
            {
                throw new Exception("Erro ao chamar API de validação de texto.");
            }
        }
        catch
        {
            throw new Exception("Erro ao chamar API de validação de texto.");
        }
    }
}
