using CryptoTray.Controls;
using CryptoTray.Data;
using CryptoTray.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CryptoTray
{
    static class Program
    {
        public static IConfiguration Configuration;
        private static NLog.ILogger _logger;

        [STAThread]
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _logger = LogManager.GetCurrentClassLogger();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainFrm = serviceProvider.GetRequiredService<App>();
                Application.Run(mainFrm);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("api-entries.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            var apiConfiguration = Configuration.GetSection("apiConfiguration");
            services.AddLogging(log =>
            {
                log.ClearProviders();
                log.AddNLog();
            });
            services.Configure<ApiConfiguration>(apiConfiguration);
            services.AddSingleton<ITickerProvider>(x => x.GetService<TickerProvider>());
            services.AddSingleton<TaskbarIconHelper>();
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ApiConfiguration>>().Value);
            services.AddSingleton<ContextMenuControl>();
            services.AddSingleton<App>();
            services.BuildServiceProvider();
        }

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            _logger.Error($"Application Exception: {t.Exception.Message}");
            _logger.Error(t.Exception.ToString());
        }

    }
}