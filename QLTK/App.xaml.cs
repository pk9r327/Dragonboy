using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QLTK.Models;
using QLTK.Services;
using QLTK.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace QLTK;

// For more information about application lifecycle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview

public partial class App : Application
{
    private IHost? _host;

    public T? GetService<T>()
        where T : class
        => _host?.Services.GetService(typeof(T)) as T;

    public App()
    {
    }

    /// <summary>
    /// Gets the current <see cref="App"/> instance in use
    /// </summary>
    public new static App Current => (App)Application.Current;


    private async void OnStartup(object sender, StartupEventArgs e)
    {
        //// https://docs.microsoft.com/windows/apps/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop
        //ToastNotificationManagerCompat.OnActivated += (toastArgs) =>
        //{
        //    Current.Dispatcher.Invoke(async () =>
        //    {
        //        var config = GetService<IConfiguration>();
        //        config[ToastNotificationActivationHandler.ActivationArguments] = toastArgs.Argument;
        //        await _host.StartAsync();
        //    });
        //};

        //var activationArgs = new Dictionary<string, string>
        //{
        //    { ToastNotificationActivationHandler.ActivationArguments, string.Empty }
        //};
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? 
            throw new DirectoryNotFoundException("Cannot find the application location");

        // For more information about .NET generic host see  https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
        _host = Host.CreateDefaultBuilder(e.Args)
                .ConfigureAppConfiguration(c =>
                {
                    c.SetBasePath(appLocation);
                    //c.AddInMemoryCollection(activationArgs);
                })
                .ConfigureServices(ConfigureServices)
                .Build();

        //if (ToastNotificationManagerCompat.WasCurrentProcessToastActivated())
        //{
        //    // ToastNotificationActivator code will run after this completes and will show a window if necessary.
        //    return;
        //}

        await _host.StartAsync();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // App Host
        services.AddHostedService<ApplicationHostService>();

        services.AddSingleton<SaveSettings>();
        services.AddSingleton<AsynchronousSocketListener>();

        services.AddSingleton<MainViewModel>();

        services.AddSingleton<MainService>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        if (_host is not null)
        {
            await _host.StopAsync();
            _host.Dispose();
            _host = null;
        }
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // TODO: Please log and handle the exception as appropriate to your scenario
        // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
    }
}
