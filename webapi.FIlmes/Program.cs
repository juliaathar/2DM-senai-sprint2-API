using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//adiciona o servico de controller
builder.Services.AddControllers();

//adiciona informações sobre a API no Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes API",
        Description = "API para cadastrar gêneros e filmes - Introdução da sprint 2 - Back-end API",
        Contact = new OpenApiContact
        {
            Name = "Júlia",
            Url = new Uri("https://github.com/juliaathar")
        }
    });

    // configura o swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

//comeca a configuracaos do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//finaliza a configuracao do swagger

//adiciona mapeamento dos controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();