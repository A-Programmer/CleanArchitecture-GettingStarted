using Project.Application;
using Project.Common;
using Project.Domain;
using Project.Infrastructure;
using Project.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterPresentation();
builder.Services.RegisterInfrastructure();
builder.Services.RegisterApplication();
builder.Services.RegisterDomain();
builder.Services.RegisterCommon();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCommon();
app.UseDomain();
app.UseApplication();
app.UseInfrastructure();
app.UsePresentation();

app.Run();
