// See https://aka.ms/new-console-template for more information
using Application;
using Application.Domain.Entities.Deposits;
using Application.Domain.Interactors.DepositIteractors;
using DomainFluentNotificator.Domain;
using DomainFluentNotificator.Infrastructure.ConsoleNotificator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices(services =>
{
    services.AddSingleton<INotificator<DepositUserCaseMessage>, ConsoleNotificator<DepositUserCaseMessage>>();
    services.AddScoped<INotificator, ConsoleNotificator2>();
    services.AddScoped<INotificatorSimple, ConsoleNotificatorSimple>();

    services.AddSingleton<DepositUserCase<Deposit>>();
    services.AddHostedService<Worker>();
});

IHost host = builder.Build();
host.Run();
