﻿using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameRetailer.Startup))]
namespace GameRetailer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "ApplicationCookie",
            //    LoginPath = new PathString("/Account/Login")
            //});
        }
    }
}
