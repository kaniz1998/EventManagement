using HMS.DAL.Data;
using HMS.DAL.Generic_Implementation;
using HMS.DAL.Generic_Interface;

using HMS.Repository.Implementation;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.OpenApi.Models;
using HMS.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HMS.DAL.Seeds;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

using Microsoft.Extensions.Logging;
using Serilog;
using HMS.Repository;
using Newtonsoft.Json;


namespace Hospital_Management_System
{
    public class Program
    {
        private const string _loginOrigin = "_localorigin"; // Define the _loginOrigin constant
        public static void Main(string[] args)
        {

            // Configure Serilog here
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //add newtonsoft.json support

            //builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });


            //add cors policy
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalManagement", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            builder.Services.AddDbContext<HospitalDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("appCon")));


            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<HospitalDbContext>();

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:Key"]);
                var issuer = builder.Configuration["JWTConfig:Issuer"];
                var audience = builder.Configuration["JWTConfig:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience
                };
            });


            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>)); 
            builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
            builder.Services.AddScoped<INurseRepo, NurseRepo>();
            builder.Services.AddScoped<ILabTechnicianRepo, LabTechnicianRepo>();
            builder.Services.AddScoped<IOtherEmployeeRepo, OtherEmployeeRepo>();
            builder.Services.AddScoped<IOutdoorRepo,OutdoorRepo>();
            builder.Services.AddScoped<IAppointmentRepo, AppointmentRepo>();

            builder.Services.AddScoped<IServiceRepo, ServiceRepo>();
            builder.Services.AddScoped<IManufacturerRepo, ManufacturerRepo>();
            builder.Services.AddScoped<IMedicineGenericRepo, MedicineGenericRepo>();
            builder.Services.AddScoped<IDrawerRepo, DrawerRepo>();
            builder.Services.AddScoped<IDrawerInfoRepo, DrawerInfoRepo>();

            builder.Services.AddScoped<ImageHelper>();

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            var app = builder.Build();


            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                    UserAndRoleDataInitializer.SeedData(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagement v1"));
            }
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors(_loginOrigin);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}