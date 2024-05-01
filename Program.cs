using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace UBFAutomation
{
    public class Program
    {

        public static void Main()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false)
                .Build();

            var appSetting = new Config();
            config.GetSection("ApplicationSettings").Bind(appSetting);

            var browserSettings = new Dictionary<string, bool>
            {
                { "Chrome", appSetting.ChromeEnabled },
                { "Firefox", appSetting.FirefoxEnabled },
                { "Internet Explorer", appSetting.IEEnabled },
                { "Edge", appSetting.EdgeEnabled },
                { "Opera", appSetting.OperaEnabled },
                { "Brave", appSetting.BraveEnabled },
                { "Safari", appSetting.SafariEnabled }
            };

            var enabledBrowsers = browserSettings
                               .Where(kvp => kvp.Value)
                               .Select(kvp => kvp.Key)
                               .ToList();

            while (true)
            {
                foreach (var browser in enabledBrowsers)
                {
                    Process.GetProcessesByName(browser).ToList().ForEach(p =>
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Could not kill process {p.ProcessName}. Error: {ex.Message}");
                        }
                    });
                }

                // Wait a bit before scanning again
                Thread.Sleep(1000);
            }

        }


        public class Config
        {
            public bool ChromeEnabled { get; set; }
            public bool FirefoxEnabled { get; set; }
            public bool IEEnabled { get; set; }
            public bool EdgeEnabled { get; set; }
            public bool OperaEnabled { get; set; }
            public bool BraveEnabled { get; set; }
            public bool SafariEnabled { get; set; }
        }


    }
}
