using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Server.Entities;
using huypq.SwaMiddleware;

namespace Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddSwaWithTrustedConnection<PhuDinhServerContext, SwaUser, SwaGroup, SwaUserGroup>("PhuDinh", @"C:\keys");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseCors(builder => builder.WithOrigins("http://localhost", "http://luoithepvinhphat.com", "http://gaucon.net").AllowAnyHeader().AllowAnyMethod());

            app.UseSwaWithTokenAuthentication("Server");
            //app.UseSwa("Server");
        }
    }
}
