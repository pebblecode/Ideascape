using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ideascape.Data;

namespace Ideascape
{
    using Models;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IdeaDataStore.Instance = new IdeaDataStore();

            ModelBinders.Binders.Add(typeof(NewIdeaSubmission), new NewIdeaSubmissionBinder());
        }
    }
}