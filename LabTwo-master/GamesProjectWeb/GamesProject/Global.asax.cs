using GamesProject.App_Start;
using System.Web.Http;

namespace GamesProject
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InjectorConfig.Configure(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
