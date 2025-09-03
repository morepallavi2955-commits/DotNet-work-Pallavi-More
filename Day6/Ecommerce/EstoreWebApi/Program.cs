var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//rest API  with HTTP Get Request using minimal APIs
app.MapGet("/hello", () =>
{
    return "Hello World!";
});

app.MapGet("/api/products", () =>
{
    return new[]
    {
        new { Id = 1, Name = "Gerbera", Price = 9.99 },
        new { Id = 2, Name = "Rose", Price = 19.99 },
        new { Id = 3, Name = "Tulip", Price = 29.99 }
    };
});

app.Run();


