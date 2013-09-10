using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebCMS
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();

            routes.MapPageRoute("Home", "{lang}/", "~/Default.aspx");
            routes.MapPageRoute("About", "{lang}/gioi-thieu", "~/About.aspx");
            routes.MapPageRoute("Contact", "{lang}/lien-he", "~/Contact.aspx");
            routes.MapPageRoute("News", "{lang}/tin-tuc/{cat}/{tag}", "~/News.aspx");
        }
    }
}