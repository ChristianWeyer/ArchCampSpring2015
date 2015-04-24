using ConfDude.Services;
using Contracts;
using System;
using System.Windows;

namespace ConfDude
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            this.InitializeServices();
        }

        private void InitializeServices()
        {
            var moduleService = new ModuleService();
            ServicePool.Current.AddService<IModuleService>(moduleService);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception).Message, "Aua! (AppDomain)");
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Aua! (App)");
            e.Handled = true;
        }
    }
}
