using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentCenterApi.src.Infrastructure.Data.Context;
using StudentCenterApi.src.Infrastructure.Dependency_Injection;
using StudentCenterApi.src.Infrastructure.Util;
using System.Text;

namespace StudentCenterApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);        

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("https://studentcenterweb-f9bucggxcjcrescj.brazilsouth-01.azurewebsites.net", 
                                        "https://studentcenteracademic-b8b6ajakhcg4dsbx.brazilsouth-01.azurewebsites.net",
                                        "https://localhost:7260",
                                        "https://localhost:7236") 
                           .AllowCredentials() 
                           .AllowAnyHeader()   
                           .AllowAnyMethod();  
                });
            });


            var connectionString = builder.Configuration.GetConnectionString("SCConnection");

            //builder.Services.AddDbContext<StudentCenterContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<StudentCenterContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentCenterApi", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Enter 'Bearer' [space] and your token!",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In= ParameterLocation.Header
                        },
                        new List<string> ()
                    }
                 });
            });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInterfaces(builder.Configuration);     
            
            builder.Services.AddSignalR();

            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://studentcenterauthapi-gna4fkhdgmbyg8cc.brazilsouth-01.azurewebsites.net",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            var app = builder.Build();
           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHub<StatusHub>("/statusHub");

            app.Run();
        }
    }
}
