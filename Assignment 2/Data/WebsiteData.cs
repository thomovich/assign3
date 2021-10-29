using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Assignment1_DNP1.Data
{
    public class WebsiteData : IAdultdata
    {
        private IList<Adult> adults;
        private FileContext _fileContext;
        public string AdultFile = "adults.json";

        public WebsiteData() {
            if (!File.Exists(AdultFile))
            {
                
                WriteAdultFile();
            }
            else
            {
                string content = File.ReadAllText(AdultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
            
        }


        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            adults.Add(adult);
            WriteAdultFile();
        }

        

        public void RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultFile();
        }

        private void WriteAdultFile()
        {
            string todoAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, todoAsJson);
        }

        private void WriteAdultsToFile()
        {
            string adultasJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, adultasJson);
            _fileContext.SaveChanges();
        }

        

        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            using HttpClient client = new HttpClient(); HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:50001");

            if (!responseMessage.IsSuccessStatusCode) throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return adults;
        }

        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            WriteAdultFile();
        }
        
        
    }
}