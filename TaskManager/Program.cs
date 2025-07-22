//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.OpenApi.Models;
//using MyApp.Infrastructure;
//using TaskManager.Application.Mappings;
//using TaskManager.Application.Handlers;

//var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
//});

//builder.Services.AddInfrastructureDI();
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskManager.Application.Handlers.CreateToDoTaskHandler).Assembly));


////builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1"));
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

//app.Run();


//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;
//using MyApp.Infrastructure;
//using TaskManager.Application.Mappings;
//using TaskManager.Infrastructure;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
//});

//// Add Infrastructure DI
//builder.Services.AddInfrastructureDI();

//// Add Blazor support (for Server-Side Blazor)
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//// Add HTTP Client for API calls
//builder.Services.AddHttpClient("TaskManagerApi", client =>
//{
//    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
//});

//// Add AutoMapper and MediatR
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskManager.Application.Handlers.CreateToDoTaskHandler).Assembly));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1"));
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

//// Map Blazor and API endpoints
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
//app.MapControllers();

//app.Run();



//using AutoMapper;
//using MediatR;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.OpenApi.Models;
//using MyApp.Infrastructure;
//using TaskManager.Application.Mappings;
//using TaskManager.Infrastructure;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
//});

//// Add Infrastructure DI
//builder.Services.AddInfrastructureDI();

//// Add Blazor support (for Server-Side Blazor)
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//// Add HTTP Client with BaseAddress
//builder.Services.AddHttpClient("TaskManagerApi", client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"] ?? builder.Environment.ContentRootPath);
//}).ConfigurePrimaryHttpMessageHandler(() =>
//{
//    return new HttpClientHandler
//    {
//        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true // For local dev
//    };
//});

//// Add AutoMapper and MediatR
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskManager.Application.Handlers.CreateToDoTaskHandler).Assembly));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1"));
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

//// Map Blazor and API endpoints
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
//app.MapControllers();

//app.Run();


using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyApp.Infrastructure;
using TaskManager.Application.Mappings;
using TaskManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
});

// Add Infrastructure DI
builder.Services.AddInfrastructureDI();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly); // Updated to use assembly

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TaskManager.Application.Handlers.CreateToDoTaskHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();