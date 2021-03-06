﻿using SlightLibs.Config.Json;
using SlightLibs.Service;
using SlightLibs.WPF.Services;
using SlightLibs.WPF.Tests.ViewModels;
using System.Windows;

namespace SlightLibs.WPF.Tests
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceProvider.Instance.InjectServices();

            ServiceProvider.Instance
                .GetService<JsonConfiguration>()?
                .Load();

            ServiceProvider.Instance
                    .GetService<IWindowService>()
                    .Create<MainViewModel>();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            ServiceProvider.Instance
                .GetService<JsonConfiguration>()?
                .Save();
        }
    }
}