using System.Windows;
using Wpf_Strategka.Pages;

namespace Wpf_Strategka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ChoosingCharactersClass());

        }
    }
}
