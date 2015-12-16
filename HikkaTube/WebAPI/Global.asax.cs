using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Core.Authentication;
using DataSource;
using DependencyResolver;
using DependencyResolver.DependencyResolvers;
using Ninject;
using User = Core.Authentication.Models.User;

namespace WebAPI
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      var registrations = new NinjectRegistrations();
      var kernel = new StandardKernel(registrations);
      System.Web.Mvc.DependencyResolver.SetResolver(new NinjectResolver(kernel));
    }

    protected void Application_PostAuthenticateRequest()
    {
      var authCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
      if (authCookies != null)
      {
        var ticket = FormsAuthentication.Decrypt(authCookies.Value);
        var js = new JavaScriptSerializer();
        if (ticket != null)
        {
          var user = js.Deserialize<User>(ticket.UserData);
          var userIdentity = new UserIdentity(user);
          var userPrincipal = new UserPrincipal(userIdentity);
          HttpContext.Current.User = userPrincipal;
        }
      }
    }
  }
}
