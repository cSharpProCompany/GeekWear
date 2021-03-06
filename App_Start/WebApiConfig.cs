﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GeekWear
{
	public static class WebApiConfig
	{
		public static string UrlPrefix { get { return "api"; } }

		public static string UrlPrefixRelative { get { return "~/api"; } }

		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
			var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			formatter.SerializerSettings.ContractResolver =
				new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
		}
	}
}
