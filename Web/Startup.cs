using System;
using MediatR;
using Core.Exceptions;
using Core.Validations;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Core.Services.Patients.Create;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web
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
            //Config Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Config MediatoR
            services.AddMediatR(typeof(CreatePatientCommand).Assembly);

            //Config Datacontex
            services.AddDbContext<DataContext>(conf =>
            {
                conf.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddControllersWithViews().AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<ConfigValidations>());

            services.AddScoped<INurseRepository, NurseRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            services.AddScoped<IConsultingRoomRepository, ConsultingRoomRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<MiddelwareHandler>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
