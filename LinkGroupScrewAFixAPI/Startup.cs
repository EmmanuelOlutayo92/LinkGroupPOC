using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;
using LinkGroup.ScrewAFix.Models;
using LinkGroup.ScrewAFix.Services.Interfaces;
using LinkGroup.ScrewAFix.Services.Requests;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LinkGroup.ScrewAFix.Services.Response;

namespace LinkGroupScrewAFixAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ConfigValues>(Configuration.GetSection(ConfigValues.ConfigName));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IServiceResponse, ServiceResponse>();
 

            services.AddHttpClient<IHttpRequestHandler, HttpRequestHandler>(client =>
           {
               client.Timeout = TimeSpan.FromSeconds(5);
               client.DefaultRequestVersion = HttpVersion.Version20;
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           }).ConfigurePrimaryHttpMessageHandler(handler => new HttpClientHandler()
           {
               UseDefaultCredentials = true,
               DefaultProxyCredentials = CredentialCache.DefaultCredentials,
               AutomaticDecompression = DecompressionMethods.All,
           });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
