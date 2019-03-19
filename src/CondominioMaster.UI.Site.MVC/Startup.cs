using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CondominioMaster.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioMaster.UI.Site.MVC
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
               services.Configure<CookiePolicyOptions>(options =>
               {
                 // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                 options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
               });


               services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

               services.AddAutoMapper();
               RegistersServices(services);  //registramos todos os nossos servicos 
          }

          //Incluimos o metodo  RegisterServices que registra o  auto mapper criado recentemente, e claro foi adcionado as referencias do projeto
          // e precisamos chamalo no metodo configure
          private static void RegistersServices(IServiceCollection service)
          {
               NativeInjectorMapping.RegistersServices(service);
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
                    app.UseExceptionHandler("/Home/Error");
               }

               app.UseStaticFiles();
               app.UseCookiePolicy();

               app.UseMvc(routes =>
               {
                  //* Acrecentamos para trabalhar  com area*/
                    routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    //* Acrecentamos para trabalhar  com area*/


                    routes.MapRoute(
                     name: "default",
                     template: "{controller=Home}/{action=Index}/{id?}");
               });
          }
     }
}
