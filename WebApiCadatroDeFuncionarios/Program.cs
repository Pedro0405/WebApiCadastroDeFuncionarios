using Microsoft.EntityFrameworkCore;
using WebApiCadatroDeFuncionarios.Data;
using WebApiCadatroDeFuncionarios.Services.Funciomarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Contexto>(options => options.UseMySql("Server=localhost;Port=3306;Database=FuncionariosDb;User=root;Password=123456;"
, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));
builder.Services.AddScoped<IfuncionarioServices, FuncionariosServices>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("funcionariosApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("funcionariosApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
