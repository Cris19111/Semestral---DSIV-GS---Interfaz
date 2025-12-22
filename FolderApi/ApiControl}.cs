using System;
using System.Net;
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
        private static readonly JsonSerializerOptions JsonOpts =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var uri = BuildAbsoluteUrl(endpoint); // asegúrate de tener este helper; si no, usa new Uri(_client.BaseAddress, endpoint.TrimStart('/'))
            var req = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage res = null;

            try
            {
                res = await _client.SendAsync(req);
                var payload = await res.Content.ReadAsStringAsync();

                if (!res.IsSuccessStatusCode)
                    throw BuildHttpErrorException(req, res, payload); // <- verás el body del 400

                return JsonSerializer.Deserialize<T>(payload, JsonOpts);
            }
            finally
            {
                if (res != null) res.Dispose();
                req.Dispose();
            }
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

        private static Exception BuildHttpErrorException(HttpRequestMessage req, HttpResponseMessage res, string body)
        {
            var sb = new StringBuilder();
            sb.AppendLine("HTTP " + req.Method + " " + req.RequestUri);
            sb.AppendLine("Status: " + ((int)res.StatusCode) + " " + res.ReasonPhrase);
            string shortBody = body != null && body.Length > 2000 ? body.Substring(0, 2000) + "...(truncado)" : (body ?? string.Empty);
            sb.AppendLine("Response body:").AppendLine(shortBody);

            if (res.StatusCode == HttpStatusCode.BadRequest)
                sb.AppendLine("Sugerencia: verifica ruta, token, query/body y shape del DTO.");

            return new HttpRequestException(sb.ToString());
        }

        private Uri BuildAbsoluteUrl(string endpoint)
        {
            Uri abs;
            if (Uri.TryCreate(endpoint, UriKind.Absolute, out abs)) return abs;
            var trimmed = (endpoint ?? string.Empty).TrimStart('/');
            return new Uri(_client.BaseAddress, trimmed);
        }


    }
}
