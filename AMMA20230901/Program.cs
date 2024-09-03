var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// lista de productos en memoria
var products = new List<Product>();

// obtener todos los productos
app.MapGet("/products", () => products);

// obtener un producto por Id
app.MapGet("/products/{id}", (int id) => products.FirstOrDefault(p => p.Id == id));

// crear un nuevo producto
app.MapPost("/products", (Product product) =>
{
products.Add(product);
return Results.Ok();
});



app.Run();

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}