using Microsoft.EntityFrameworkCore;
using StudentCenterApi.src.Infrastructure.Data.Context;
using StudentCenterApi.src.Infrastructure.Dependency_Injection;
using StudentCenterApi.src.Infrastructure.Util;

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
                    builder.WithOrigins("https://localhost:7236", "https://localhost:7260") 
                           .AllowCredentials() 
                           .AllowAnyHeader()   
                           .AllowAnyMethod();  
                });
            });


            var connectionString = builder.Configuration.GetConnectionString("SCConnection");

            builder.Services.AddDbContext<StudentCenterContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInterfaces(builder.Configuration);     
            
            builder.Services.AddSignalR();

            var app = builder.Build();
           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHub<StatusHub>("/statusHub");

            app.Run();
        }
    }
}
