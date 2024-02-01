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
                if (info.statsInfo.ContainsKey(buttonText) && info.heroInfo.ContainsKey(buttonText))
                {
                    HeroInfo.Text = info.heroInfo[buttonText];
                    StatsInfo.Text = info.statsInfo[buttonText];
                    string imagePath = info.heroImages[buttonText];
                    ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    ClassImg.Source = imageSource;
                }
            }
        }

    }
}
