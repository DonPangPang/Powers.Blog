using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Pang.AutoMapperMiddleware;
using Powers.Blog.Apis.Controllers;
using Powers.Blog.Apis.Extensions.EfCore;
using Powers.Blog.Core.AutoFac;
using Powers.Blog.IRepository;
using Powers.Blog.IServices;
using Powers.Blog.Repository;
using Powers.Blog.Services;
using Powers.Blog.Shared;
using System.Reflection;
using System.Text;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Powers.Blog", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    //... and tell Swagger to use those XML comments.
    c.IncludeXmlComments(xmlPath, true);
});

builder.Services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
builder.Services.AddScoped(typeof(IServiceBase<,>), typeof(ServiceBase<,>));
builder.Services.AddScoped(typeof(IRepositoryGen<>), typeof(RepositoryGen<>));
builder.Services.AddScoped(typeof(IServiceGen<>), typeof(ServiceGen<>));
builder.Services.AddScoped<IUserService, UserService>();

// AutoFac
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
//    .ConfigureContainer<ContainerBuilder>(builder =>
//    {
//        builder.RegisterModule(new AutofacModuleRegister());

// var controllerBaseType = typeof(ApiController);
// builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t =>
// controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType).PropertiesAutowired(); });

// EfCore
builder.Services.AddEfCore();
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// AutoMapper
app.UseAutoMapperMiddleware();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();