using System.Threading.Tasks;
using Assignment1_DNP1.Models;
using Models;

namespace Assignment1_DNP1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}