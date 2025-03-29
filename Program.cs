using Microsoft.EntityFrameworkCore;
using StudentCenterApi.src.Infrastructure.Data.Context;
using StudentCenterApi.src.Infrastructure.Dependency_Injection;

namespace StudentCenterApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);            

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            var connectionString = builder.Configuration.GetConnectionString("SCConnection");

            builder.Services.AddDbContext<StudentCenterContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddInterfaces(builder.Configuration);

            var app = builder.Build();
           
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }           

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
