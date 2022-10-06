using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MIDE.Helpers;
using MIDE.ViewModels;
using MIDE.Views;

namespace MIDE
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            FileHelper = new FileHelper();
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
        
        public FileHelper FileHelper { get; set;  }
    }
}