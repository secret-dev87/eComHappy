﻿using Autofac;
using Infrastructure;
using MediatR.Extensions.Autofac.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using WebApi.CustomExtensions;
using WebApi.Middleware;
using AutoMapper.Contrib.Autofac.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterMediatR(typeof(Program).Assembly);
            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new MediatorModule());
        });

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom configurations
builder.Services.AddCustomConfiguration(builder.Configuration);
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomSwagger(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var _provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        // build a swagger endpoint for each discovered API version
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            options.DefaultModelsExpandDepth(-1);
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        }

        options.DefaultModelsExpandDepth(-1);

    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
