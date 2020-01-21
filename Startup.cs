using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; 
using api_test.Database;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace api_test
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

            services.AddDbContext<CoreDbContext>(
            options => 
            options.UseMySql("server=127.0.0.1;user id=root;password=bawanggoreng;port=3306;database=api_test"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

        
            app.Use(async(context, next)=>{
                // Console.WriteLine($"{context.Response.StatusCode} here request");
                  using (StreamWriter w = File.AppendText("log.txt"))
                {
                        w.WriteLine($@"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz").Remove(26,1)}] REQUEST {context.Request.Scheme.ToUpper()} {context.Request.Method.ToUpper()} {context.Request.Host}{context.Request.Path} responded {context.Response.StatusCode}");

                await next();

                        w.WriteLine($@"[{DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz").Remove(26,1)}] RESPONSE {context.Request.Scheme.ToUpper()} {context.Request.Method.ToUpper()} {context.Request.Host}{context.Request.Path} responded {context.Response.StatusCode}");
                // Console.WriteLine($"{context.Response.StatusCode} here response");
                }

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
