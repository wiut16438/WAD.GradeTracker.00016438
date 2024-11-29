using Microsoft.EntityFrameworkCore;
using WAD.Server._00016438.DAL.Data;
using WAD.Server._00016438.DAL.Repositories;

namespace WAD.Server._00016438
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

			builder.Services.AddDbContext<GradeTrackerDbContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString("GradeTrackerConnection")
			));
			builder.Services.AddScoped<IGradesRepository, GradesRepository>();
			builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
