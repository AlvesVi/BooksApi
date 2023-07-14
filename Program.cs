using BooksApi.Database;
using BooksApi.Repositories;
using BooksApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BooksApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("BooksConnection");
            builder.Services.AddDbContext<BookContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // Interface e Repositório
            builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
            builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
            builder.Services.AddScoped<IListaLivrosRepositorio, ListaLivrosRepositorio>();
           

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "BooksAPI",
                    Version = "v1" ,
                    Description = "API para gerenciamento de leitura de livros",
                    Contact = new OpenApiContact
                    {
                        Name = "Vitórial Alves",
                        Email = "vitoriajoyce.carvalho@gmail.com",
                        Url = new Uri("https://github.com/AlvesVi"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<BookContext>();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}