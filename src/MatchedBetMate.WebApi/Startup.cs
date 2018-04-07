using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MatchedBetMate.WebApi.Data.Context;
using MatchedBetMate.WebApi.Data.Repository.Implementation;
using MatchedBetMate.WebApi.Data.Repository.Interfaces;
using MatchedBetMate.WebApi.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MatchedBetMate.WebApi
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
            // Register DbContext
            services.AddDbContext<MatchedBetMateDbContext>();
            
            // Set up identity
            ConfigureIdentity(services);

            // Setup Token Authentication
            ConfigureJwtAuthentication(services);
            
            // Register Business Services
            RegisterServices(services);

            // Register Repositories
            RegisterRepositories(services);

            // Add Mvc
            services.AddMvc();
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IBetRepository, BetRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            
        }

        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero, // remove delay of token when expire
                        NameClaimType = "unique_name",
                    };
                });
        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MatchedBetMateDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MatchedBetMateDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();

            // Setup Automapper
            Bootstrap.InitialiseAutomapper();

            // ===== Create tables ======
            dbContext.Database.EnsureCreated();
        }
    }
}
