using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Services;
using MeninasProgramadorasAPI.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MPConnection");
builder.Services.AddDbContext<AppDbContext>(opts =>
 opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAlunaService, AlunaService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IPresencaService, PresencaService>();

builder.Services.AddControllers().AddNewtonsoftJson();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
