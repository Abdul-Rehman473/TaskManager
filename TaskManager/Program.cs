using Microsoft.OpenApi.Models;
using MyApp.Infrastructure;
using TaskManager.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
});


builder.Services.AddInfrastructureDI(builder.Configuration);


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskManager.Application.Handlers.UpsertToDoTaskHandler).Assembly));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();