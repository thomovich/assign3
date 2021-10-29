using System.Threading.Tasks;
using Assignment1_DNP1.Models;
using Models;

namespace Assignment_2
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}