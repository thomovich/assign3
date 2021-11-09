using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1_DNP1.Data
{
    public class WebApiCaller : IAdultdata
    {
        public async Task<Adult> AddAdult(Adult adult)
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            
            using HttpClient client = new HttpClient(handler);
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync($"https://localhost:5001/adult", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();

            Adult adult1 = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return adult1;
        }

        public async Task RemoveAdult(int todoId)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:5001/adult/1");
            if (!response.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        }

        public async Task<Adult> Update(Adult adult)
        {
            using HttpClient client = new HttpClient();
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PatchAsync($"https://localhost:5001/adult/{adult.Id}",content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();

            Adult adult1 = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return adult1;
        }

        public async Task<Adult> Get(int id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5001/adult/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string adultAsJson = await responseMessage.Content.ReadAsStringAsync();

            Adult adult = JsonSerializer.Deserialize<Adult>(adultAsJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return adult;
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            
            using HttpClient client = new HttpClient(handler);
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5001/adult");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return adults;
        }
    }
}