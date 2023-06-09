using QrCodeGenerator.ViewModels;
using System.Windows;

namespace QrCodeGenerator
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
