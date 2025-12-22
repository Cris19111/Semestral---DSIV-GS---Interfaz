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
            _client.BaseAddress = new Uri("http://srv595743.hstgr.cloud:5000/");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Comprueba si la API está accesible (verifica swagger)
        public async Task<bool> ApiConectadaAsync()
        {
            HttpResponseMessage response =
                await _client.GetAsync("swagger/index.html");

            return response.IsSuccessStatusCode;
        }

        // Realiza una petición GET y deserializa el JSON al tipo T
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

        // Realiza una petición POST enviando TRequest y deserializa la respuesta a TResponse
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

        // Establece el token Bearer para la autorización en el cliente
        public void SetToken(string token)
        {
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        // Realiza una petición POST y devuelve la respuesta como texto
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

        // Realiza una petición PUT con el cuerpo serializado
        public async Task PutAsync<TRequest>(string endpoint, TRequest data)
        {
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync(endpoint, content);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error {(int)response.StatusCode}:\n{responseJson}");
        }

        // Realiza una petición DELETE al endpoint indicado
        public async Task DeleteAsync(string endpoint)
        {
            HttpResponseMessage response = await _client.DeleteAsync(endpoint);
            string responseJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error {(int)response.StatusCode}:\n{responseJson}");
        }


    }
}
