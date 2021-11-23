using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Library.Models;

namespace Assignment_2
{
    public class WebsiteData : IAdultdata
    {
        private IList<Adult> adults;
      
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

        public async Task<Adult> AddAdult(Adult adult)
        {
            adults.Add(adult);
            WriteAdultFile();
            return adult;
        }

        

        public async Task RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultFile();
        }

        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            WriteAdultFile();
            return toUpdate;
        }
        
      

        private void WriteAdultFile()
        {
            string todoAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, todoAsJson);
        }

      /*  private void WriteAdultsToFile()
        {
            string adultasJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, adultasJson);
            _fileContext.SaveChanges();
        }*/
        
        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {

            return adults;
        }
        
        
        
    }
}