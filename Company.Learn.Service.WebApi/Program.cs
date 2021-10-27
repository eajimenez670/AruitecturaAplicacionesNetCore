using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Company.Learn.Service.WebApi
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Program'
    public class Program
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Program'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Program.Main(string[])'
        public static void Main(string[] args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Program.Main(string[])'
        {
            CreateHostBuilder(args).Build().Run();
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Program.CreateHostBuilder(string[])'
        public static IHostBuilder CreateHostBuilder(string[] args) =>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Program.CreateHostBuilder(string[])'
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
