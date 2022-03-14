using System.Windows;
using EFCoreDemo.Data;
using EFCoreDemo.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EFCoreDemo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost? Host { get; private set; }
    public static MainViewModel? MainViewModel
        => Host?.Services.GetService<MainViewModel>();

    public App()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddDbContextFactory<MyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyDbContext")));
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
            }).Build();
    }
    protected override void OnStartup(StartupEventArgs args)
    {
        base.OnStartup(args);

        Host.Start();
        Host?.Services.GetService<MainWindow>()?.Show();
    }
}