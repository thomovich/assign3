using System.Threading.Tasks;
using Library.Models;

namespace Assignment_2
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string Password);
    }
}