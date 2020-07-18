using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium.Chrome;

namespace SeleniumInDocker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var env = Environment.GetEnvironmentVariable(@"INSTALL_DOCKER_PATH");
            var dirictory = Directory.GetCurrentDirectory();

            while (!stoppingToken.IsCancellationRequested)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--headless");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usag");
                var driverPath = Path.GetFullPath(Path.Combine(dirictory, "bin/Debug/netcoreapp2.2"));

                var driver = new ChromeDriver(driverPath, options);

                driver.Url = "https://www.geeksforgeeks.org/";
                Console.WriteLine("123");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
