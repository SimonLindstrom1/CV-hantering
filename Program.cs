using CV_hantering_REST_API;
using CV_hantering_REST_API.Endpoints;
using CV_hantering_REST_API.Services;

namespace CV_hantering_REST_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register GitHubService with HttpClient
            builder.Services.AddHttpClient<GitHubServices>(client =>
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("request");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Register endpoints
            CVendpoints.RegisterEndpoints(app);

            app.Run();
        }
    }
}