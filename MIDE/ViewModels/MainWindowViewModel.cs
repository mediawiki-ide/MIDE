namespace MIDE.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => Globals.FileHelper.Wikitext;
    }
}