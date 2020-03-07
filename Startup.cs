using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCSharpRESTful.Models;
using BasicCSharpRESTful.Options;
using DevelopmentUtilitiesRESTful.Models;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace BasicCSharpRESTful
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
               services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

               services.AddMvc(op =>
               {
                    foreach (var formatter in op.OutputFormatters
                        .OfType<ODataOutputFormatter>()
                        .Where(it => !it.SupportedMediaTypes.Any()))
                    {
                         formatter.SupportedMediaTypes.Add(
                             new MediaTypeHeaderValue("application/prs.mock-odata"));
                    }
                    foreach (var formatter in op.InputFormatters
                        .OfType<ODataInputFormatter>()
                        .Where(it => !it.SupportedMediaTypes.Any()))
                    {
                         formatter.SupportedMediaTypes.Add(
                             new MediaTypeHeaderValue("application/prs.mock-odata"));
                    }
               });

               services.AddOData();

               services.AddSwaggerGen(x => {
                    x.SwaggerDoc("v1", new Info { Title = "DevelopmentUtility RESTful API", Version = "v1" });
                    });

               services.AddDbContext<DevelopmentUtilitiesV2Context>
               (options => options.UseSqlServer
                    (Configuration["Data:DevelopmentUtilitiesV2Connection:ConnectionString"])
               );
               services.AddDbContext<DevelopmentUtilitiesContext>
                    (options => options.UseSqlServer
                         (Configuration["Data:DevelopmentUtilitiesConnection:ConnectionString"])
                    );
               
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IHostingEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }
               else
               {
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
               }

               var swaggerOptions = new SwaggerOptions();
               Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

               app.UseSwagger(option => { option.RouteTemplate = 
                    swaggerOptions.JsonRoute; });

               app.UseSwaggerUI(option => { option.SwaggerEndpoint(   
                    swaggerOptions.UiEndpoint, 
                         swaggerOptions.Description); });

               app.UseHttpsRedirection();
               app.UseStaticFiles();
               app.UseMvc(routeBuilder => {

                    routeBuilder.EnableDependencyInjection();

                    routeBuilder.Expand().Select().OrderBy().Filter();

               });               
          }
     }
}
