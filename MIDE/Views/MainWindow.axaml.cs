using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MIDE.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_OnClick(object? sender, RoutedEventArgs e)
        {
            Globals.FileHelper.NewFile();
            
            Window.Title = "New File - MIDE";
        }

        private async void Open_OnClick(object? sender, RoutedEventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog
            {
                Title = "Open File",
                Filters = Globals.FileHelper.CreateFilters(),
                AllowMultiple = false
            };

            string[] files = await Dialog.ShowAsync(this);

            if (files.Length > 0)
            {
                Globals.FileHelper.LoadFile(files[0]);
                
                if (Globals.FileHelper.DidLastLoadSucceed)
                {
                    Window.Title = Globals.FileHelper.Path + " - MIDE";
                    Wikitext.Text = Globals.FileHelper.Wikitext;
                }
                
            }
        }

        private void Exit_OnClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}