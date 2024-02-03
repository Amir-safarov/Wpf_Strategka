using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Strategka.Classes;
using Wpf_Strategka.Constants;

namespace Wpf_Strategka.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoosingCharactersClass.xaml
    /// </summary>
    public partial class ChoosingCharactersClass : Page
    {
        ClassesInfo info = new ClassesInfo();
        public ChoosingCharactersClass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string buttonText = button.Content.ToString();
                App.className  = buttonText;
                if (info.statsInfo.ContainsKey(buttonText) && info.heroInfo.ContainsKey(buttonText))
                {
                    HeroInfo.Text = info.heroInfo[App.className];
                    StatsInfo.Text = info.statsInfo[App.className];
                    string imagePath = info.heroImages[App.className];
                    ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    ClassImg.Source = imageSource;
                }
            }
        }

        private void NextBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharacterСharacteristics());
        }
    }
}
