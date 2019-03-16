using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyStrategy.Api.Contracts.Groupers;
using EasyStrategy.Api.Data;
using EasyStrategy.Api.Services;
using EasyStrategy.Domain.Groupers;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OData.Edm;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace EasyStrategy.Api
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
            services.AddDbContext<EasyContext>(options => {
                options.UseMySql(Configuration.GetConnectionString("EasyConnection"),
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                    });
                }
            );

            services.AddScoped<IGrouperApiService, GrouperApiService>();

            services.AddOData();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc(_ =>
            {
                _.EnableDependencyInjection();
                _.Count().Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                _.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }


        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Grouper>("Groupers");
            builder.EntitySet<GrouperType>("GrouperTypes");
            return builder.GetEdmModel();
        }
    }
}
