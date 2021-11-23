using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Dataacces;
using Library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Assignment_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ViaDBContext viaDbContext = new ViaDBContext())
            {
                if (!viaDbContext.Adults.Any())
                {
                    Seed(viaDbContext);
                }
            }
            
            CreateHostBuilder(args).Build().Run();
        }

        private static void Seed(ViaDBContext viaDbContext)
        {
            Adult adult = new Adult();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}