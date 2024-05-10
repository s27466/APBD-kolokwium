using OrderApp.Repositories;
using OrderApp.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();

        var app = builder.Build();

        //Configuring the HTTP request pipeline
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}