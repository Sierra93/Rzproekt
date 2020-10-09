using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Rzproekt {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseStartup<Startup>().UseKestrel(o => o.Limits.MaxRequestBodySize = 100_000_000);
                });

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //WebHost.CreateDefaultBuilder(args)
    //    .UseStartup<Startup>()
    //    .UseKestrel(options => {
    //        options.Limits.MaxRequestBodySize = 100000000;
    //    });
    }
}
