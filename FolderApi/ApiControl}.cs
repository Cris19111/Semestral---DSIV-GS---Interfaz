using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Semestral___DSIV_GS.FolderApi
{
    internal class ApiControl_
    {
        private readonly HttpClient _client;

        public ApiControl_()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri("https://localhost:7229/");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> ApiConectadaAsync()
        {
            HttpResponseMessage response =
                await _client.GetAsync("swagger/index.html");

            return response.IsSuccessStatusCode;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            HttpResponseMessage response = await _client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(
            string endpoint, TRequest data)
        {
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =
                await _client.PostAsync(endpoint, content);

            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"Error {(int)response.StatusCode}:\n{responseJson}"
                );
            }

            return JsonSerializer.Deserialize<TResponse>(
                responseJson,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<string> PostTextoAsync<TRequest>(
    string endpoint, TRequest data)
        {
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response =
                await _client.PostAsync(endpoint, content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

    }
}
