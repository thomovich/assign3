using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1_DNP1.Data
{
    public class WebApiCaller : IAdultdata
    {
        public IList<Adult> GetAdults()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> RemoveAdult(int todoId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> Update(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> Get(int id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:50001/adult/{id}");

            
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:50001/adult");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return adults;
        }
    }
}