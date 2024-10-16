
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Interfaces;
using RepositoryPattern.EF;
using RepositoryPattern.EF.Configration;
using RepositoryPattern.EF.Repositories;

namespace RepositoryPattern.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //###
            builder.Services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(
                "Server=.; Database=RepositoryPatternDB; Integrated Security=SSPI; TrustServerCertificate = True "
                //"Server(localdb)\\MSSQLLocalDB;Database=RepositoryPatternDB;Integrated Security=True"
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //###

            //builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
