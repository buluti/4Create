using _4Create.Api.Middleware;
using _4Create.Application;
using _4Create.Infrastructure;
using _4Create.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

builder.Services.AddControllers()
    .AddApplicationPart(_4Create.Presentation.AssemblyReference.Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging();
builder.Services.AddTransient<GlobalErrorHandlingMiddleware>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseMiddleware<GlobalErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}