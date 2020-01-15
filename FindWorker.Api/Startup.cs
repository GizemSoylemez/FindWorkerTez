using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindWorker.Data.Abstract;
using FindWorker.Data.Concrete.Ef;
using FindWorker.Entity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Test
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

            services.AddDbContext<FindWorkersTezContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUserRepository, EfUserRepository>();
            services.AddTransient<IAdvertRepository, EfAdvertRepository>();
            services.AddTransient<ICompanyRepository, EfCompanyRepository>();
            services.AddTransient<IContactRepository, EfContactRepository>();
            services.AddTransient<ICvDataRepository, EfCvdataRepository>();
            services.AddTransient<IDocumentRepository, EfDocumentRepository>();
            services.AddTransient<IEducationRepository, EfEducationRepository>();
            services.AddTransient<IHobbyRepository, EfHobbyRepository>();
            services.AddTransient<ILanguageRepository, EfLanguageRepository>();
            services.AddTransient<ILocationRepository, EfLocationRepository>();
            services.AddTransient<IMessageRepository, EfMessageRepository>();
            services.AddTransient<IProjectRepository, EfProjectRepository>();
            services.AddTransient<IReferenceRepository, EfReferenceRepository>();
            services.AddTransient<IRoleRepository, EfRoleRepository>();
            services.AddTransient<ISkillRepository, EfSkillRepository>();
            services.AddTransient<IWorkExperienceRepository, EfWorkExperienceRepository>();
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();


            /*services.AddIdentity<Role, IdentityRole>()
                .AddEntityFrameworkStores<FindWorkersTezContext>()
                .AddDefaultTokenProviders();*/

            services.AddAuthentication(
                option => {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                )
                .AddJwtBearer(
                option =>
                {
                    option.SaveToken = true;
                    option.RequireHttpsMetadata = false;
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = "http://cbank.com",
                        ValidIssuer = "http://cbank.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"))
                    };
                }
                );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = new PathString("/vendor")
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
