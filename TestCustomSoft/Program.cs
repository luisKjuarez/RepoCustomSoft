using Aplicacion;
using Aplicacion.Servicios.impl;
using Aplicacion.Servicios.interfaces;
using Infraestructura;
using Infraestructura.Repositorios;
using Infraestructura.Repositorios.Generico;
using Infraestructura.Repositorios.implementacion;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddApplicationServices( );
builder.Services.AddInfraestructuraService(builder.Configuration.GetConnectionString("CadenaConexion"));
builder.Services.AddScoped<IVentaRepository, VentaRepositoryImpl>();
builder.Services.AddScoped<IApiKeyValidator, ApiKeyValidator>();
builder.Services.AddScoped<ITransformToDirectory, TransformToDirectoryImpl>(); 
builder.Services.AddScoped<IDocumentoRepository, DocumentoRepositoryImpl>();

builder.Services.Configure<FormOptions>(option =>
{
    option.ValueLengthLimit = int.MaxValue;
    option.MultipartBodyLengthLimit = 4L * 1024L * 1024L * 1024L;
    option.MultipartBoundaryLengthLimit = int.MaxValue;
    option.MultipartHeadersCountLimit = int.MaxValue;
    option.MultipartHeadersLengthLimit = int.MaxValue;
    option.BufferBodyLengthLimit = 4L * 1024L * 1024L * 1024L;
    option.BufferBody = true;
    option.ValueCountLimit = int.MaxValue;
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors(
        options => options.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Content-Disposition")
    );

app.UseAuthorization();

app.MapControllers();

app.Run();
