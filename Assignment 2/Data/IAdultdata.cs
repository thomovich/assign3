using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Assignment1_DNP1.Models;
using Models;

namespace Assignment1_DNP1.Data
{
    public interface IAdultdata
    {
        
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
        void RemoveAdult(int todoId);
        void Update(Adult adult);
        Adult Get(int id);
        Task<IList<Adult>> GetAdultsAsync();
    }
}