using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging;
using Serilog;
using dummy_dot_net_framework_web_app.Telemetry.Initializers;
using System.Net;
using Identity;


namespace dummy_dot_net_framework_web_app
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static void Log(ILogger<MvcApplication> log)
        {
            log.LogInformation("debug: {0}", DateTime.UtcNow);
            Console.WriteLine("Interval Called");
        }

        protected void Application_Start()
        {
            var credential = Identity.Azure.ManagedIdentityCredential();
            TelemetryConfiguration.Active.SetAzureTokenCredential(credential);
            TelemetryConfiguration.Active.ConnectionString = "InstrumentationKey=972dd88b-6ac3-4022-a8ad-a5d86bc9491d;IngestionEndpoint=https://southafricanorth-1.in.applicationinsights.azure.com/;LiveEndpoint=https://southafricanorth.livediagnostics.monitor.azure.com/";
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new ApplicationDefaults());

            // https://github.com/serilog-contrib/serilog-sinks-applicationinsights

            // TelemetryConverter.Events is preferred over TelemetryConverter.Traces because TelemetryConverter.Events is not adaptively sampled (ie, for logs/events you will get the true set of logs). Adaptively samples are for cost control.
            var loggerConfiguration = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Events).CreateLogger(); 

            var logger = new LoggerFactory().AddSerilog(loggerConfiguration);
            var log = logger.CreateLogger<MvcApplication>();
            
            var timer = new System.Timers.Timer(interval: 3000);
            timer.Elapsed += (sender, e) => Log(log);
            timer.Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
