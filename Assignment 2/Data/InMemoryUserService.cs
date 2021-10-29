using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1_DNP1.Models;
using Models;

namespace Assignment_2
{
    public class InMemoryUserService : IUserService
    {
        
        
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    City = "Aarhus",
                    Domain = "via.dk",
                    Password = "123456",
                    Role = "Teacher",
                    BirthYear = 1998,
                    SecurityLevel = 5,
                    UserName = "Christina"
                },
                new User
                {
                    City = "Aarhus",
                    Domain = "hotmail.com",
                    Password = "123456",
                    Role = "Student",
                    BirthYear = 1997,
                    SecurityLevel = 3,
                    UserName = "Emma"
                },
                
                new User
                {
                    City = "Aarhus",
                    Domain = "via.com",
                    Password = "123456",
                    Role = "Guest",
                    BirthYear = 1997,
                    SecurityLevel = 1,
                    UserName = "Asbjørn"
                }
            }.ToList();
        }

        public async Task<User> ValidateUser(string userName, string Password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}