using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment_2
{
    public interface IAdultdata
    {
        
        //IList<Adult> GetAdults();
       Task<Adult>  AddAdult(Adult adult);
       Task RemoveAdult(int todoId);
        Task<Adult> UpdateAsync(Adult adult);
        //Adult Get(int id);
        Task<IList<Adult>> GetAdultsAsync();
    }
}