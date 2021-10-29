using System;
using System.Threading.Tasks;
using Assignment1_DNP1.Data;
using Assignment1_DNP1.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodosWebAP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

 
    }
}