using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ZooLibrary.Model;

namespace AspCoreZoo
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
            services.AddDbContext<ZooContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ZooDatabase"))
                    /*ServiceLifetime.Scoped*/
                );
            //services.AddScoped<ZooContext>();
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





            //_context = app.ApplicationServices.GetRequiredService<ZooContext>();
            _scope = app.ApplicationServices.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<ZooContext>();
            Task.Run(() => ZooEngineTick());
        }

        private IServiceScope _scope;
        private ZooContext _context;
        private void ZooEngineTick()
        {
            Thread.Sleep(10000);//pause 10 second per processing, also 'fixes' DBContext bug 'still configuring may not access'
            var all_animals = _context.Animals.AsEnumerable();
            foreach (var animal in all_animals)
            {
                animal.UseEnergy();
                if (!animal.IsAlive)
                    _context.Animals.Remove(animal);
            }
            //_context.UpdateRange(all_animals);
            _context.SaveChanges();
            foreach(var animal in all_animals)
            {
                _context.Entry<Animal>(animal).State = EntityState.Detached;
            }
            Task.Run(() => ZooEngineTick());
        }


    }
}
