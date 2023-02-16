using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
// Using Autofac for IoC
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


// .Services represents the IOC container
builder.Services.AddControllersWithViews();

//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Scoped
//));

// Shorthand
// using Microsoft DI
//builder.Services.AddScoped<ICitiesService, CitiesService>();

builder.Host.ConfigureContainer<ContainerBuilder>
(containerBuilder =>
{
    //containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();
    // similar to AddTransient

    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
    // InstancePerLifetimeScope is similar to AddScoped
    // SingleInstance is similar to AddSingleton
});


var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
