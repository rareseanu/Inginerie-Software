using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository;

namespace TrainBookingPlatform.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await CreateRoles(host);

            await host.RunAsync();
        }

        public static async Task CreateRoles(IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<TrainBookingPlatformDbContext>();
                if(context.Roles.ToList().Count < 3)
                {
                    var roles = new List<Role>
                    {
                        new Role { Name = "Administrator" },
                        new Role { Name = "Client"},
                        new Role { Name = "Ticket Inspector"}
                    };

                    context.AddRange(roles);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //rip
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
