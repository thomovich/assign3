using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment1_DNP1.Models;
using FileData;
using Microsoft.AspNetCore.Components;
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
                
                string todoAsJson = JsonSerializer.Serialize(adults);
                File.WriteAllText(AdultFile, todoAsJson);
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
            string todoAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, todoAsJson);
        }

        

        public void RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        private void WriteAdultsToFile()
        {
            string adultasJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, adultasJson);
            _fileContext.SaveChanges();
        }

        public void Update(Adult adult)
        {
            Adult adultUpdate = adults.First(t => t.Id == adult.Id);
            adultUpdate = adult;
            WriteAdultsToFile();
        }

        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }
    }
}