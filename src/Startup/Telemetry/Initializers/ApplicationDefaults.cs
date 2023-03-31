using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;


namespace dummy_dot_net_framework_web_app.Telemetry.Initializers
{

    //  https://learn.microsoft.com/en-us/azure/azure-monitor/app/configuration-with-applicationinsights-config#telemetry-initializers-aspnet
    public class ApplicationDefaults : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = "MyRoleName1";
            telemetry.Context.Cloud.RoleInstance = "MyRoleName1";
        }
    }
}



