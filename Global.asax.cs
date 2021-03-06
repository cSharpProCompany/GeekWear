﻿using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using System.Web.SessionState;

namespace GeekWear
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_PostAuthorizeRequest()
		{
			if (IsWebApiRequest)
			{
				HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
			}
		}

		private bool IsWebApiRequest
		{
			get
			{
				return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiConfig.UrlPrefixRelative);
			}
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
