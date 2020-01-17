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
using Just0ne.Model;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Just0ne.IRepository;
using Just0ne.IService;
using Just0ne.Service;
using Just0ne.Repository;

namespace Just0ne.WebFrontApi
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


        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblys = new List<Assembly>();//Service是继承接口的实现方法类库名称 
            string assemblysStr = "Just0ne.Repository^Just0ne.Service^Just0ne.IService^Just0ne.IRepository"; //程序集名称
            var baseType = typeof(IDependency);
            foreach (var item in assemblysStr.Split("^"))
            {
                assemblys.Add(Assembly.Load(item));
            }
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(m => baseType.IsAssignableFrom(m) && m != baseType).AsImplementedInterfaces().InstancePerLifetimeScope().InstancePerDependency();
        }

    }
}
