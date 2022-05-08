﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace myServices
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServicesModel _servicesModel;

        public App()
        {
            _servicesModel = new ServicesModel();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ServicesViewModel(_servicesModel)
            };
            MainWindow.Show();
            
            base.OnStartup(e);
        }
    }
}
