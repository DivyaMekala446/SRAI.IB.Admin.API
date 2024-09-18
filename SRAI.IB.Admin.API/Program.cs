using Serilog;

namespace SRAI.IB.Admin.API
{
    /// <summary>
    /// Program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">args</param>
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>HostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                });
    }
}

