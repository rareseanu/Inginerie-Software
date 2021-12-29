using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Text;
using TrainBookingPlatform.BL.Classes;
using TrainBookingPlatform.BL.Interfaces;
using TrainBookingPlatform.DAL.Repository;
using TrainBookingPlatform.DAL.Repository.Classes;
using TrainBookingPlatform.DAL.Repository.Interfaces;
using TrainBookingPlatform.Helpers.AutoMapper;

namespace TrainBookingPlatform.API
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
            services.AddDbContext<TrainBookingPlatformDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("TrainBookingPlatformDbContext")));
            services.AddControllers();
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<ITrainRepository, TrainRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IDepartureRepository, DepartureRepository>();
            services.AddScoped<IDepartureService, DepartureService>();
            services.AddScoped<IWagonRepository, WagonRepository>();
            services.AddScoped<IWagonService, WagonService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt =>
                {
                    var jwtSecret = Encoding.ASCII.GetBytes("asfasfasfasg1224124124124124safasfasfasfasf");
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(jwtSecret),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddMvc()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.SetIsOriginAllowed(origin => true);
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainBookingPlatform.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainBookingPlatform.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
