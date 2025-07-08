using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using DotNetEnv; // Add this using statement

namespace OA_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Load .env file BEFORE anything else
                var envPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "bank.env");
                if (System.IO.File.Exists(envPath))
                {
                    Env.Load(envPath);
                }
                else
                {
                    Console.WriteLine("⚠️ .env file not found at: " + envPath);
                }

                var appBasePath = System.IO.Directory.GetCurrentDirectory();
                NLog.GlobalDiagnosticsContext.Set("appbasepath", appBasePath);
                var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading .env file: {ex.Message}");
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}