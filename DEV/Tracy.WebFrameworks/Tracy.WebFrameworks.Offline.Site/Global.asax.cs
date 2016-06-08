using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Tracy.WebFrameworks.Offline.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //注册路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //注册静态资源(js&css)
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //其它注册...

        }
    }
}
