using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1_DNP1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;


namespace TodosWebAP.Controllers {
    
    [ApiController]
    [Route("[controller]")]
    public class AdultController : Controller
    {
        private IAdultdata websiteData;

        public AdultController(IAdultdata websiteData)
        {
            this.websiteData = websiteData;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetTodos([FromQuery] int? userId, [FromQuery] bool? isCompleted) {
            try
            {
                IList<Adult> adults = await websiteData.GetAdultsAsync();
                return Ok(adults);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}