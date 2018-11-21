using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Honey.IdentityServer.Config;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Honey.IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // 使用内存存储，密钥，客户端和资源来配置身份服务器。
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityConfig.GetApiResources())//添加api资源
                .AddInMemoryClients(IdentityConfig.GetClients())//添加客户端
                .AddTestUsers(IdentityConfig.GetUsers()); //添加测试用户

            //services.AddAuthentication()
            //  .AddGoogle("Google", options =>
            //  {
            //      options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //      // register your IdentityServer with Google at https://console.developers.google.com
            //      // enable the Google+ API
            //      // set the redirect URI to http://localhost:port/signin-google
            //      options.ClientId = "copy client ID from Google here";
            //      options.ClientSecret = "copy client secret from Google here";
            //  })
            //  .AddOpenIdConnect("oidc", "OpenID Connect", options =>
            //  {
            //      options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            //      options.SignOutScheme = IdentityServerConstants.SignoutScheme;

            //      options.Authority = "https://demo.identityserver.io/";
            //      options.ClientId = "implicit";

            //      options.TokenValidationParameters = new TokenValidationParameters
            //      {
            //          NameClaimType = "name",
            //          RoleClaimType = "role"
            //      };
            //  });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
