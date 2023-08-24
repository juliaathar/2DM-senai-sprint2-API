var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controller
builder.Services.AddControllers();

var app = builder.Build();

//adiciona mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();