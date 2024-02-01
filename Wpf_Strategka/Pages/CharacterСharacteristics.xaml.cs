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

namespace Wpf_Strategka.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterСharacteristics.xaml
    /// </summary>
    public partial class CharacterСharacteristics : Page
    {
        public CharacterСharacteristics()
        {
            InitializeComponent();
        }
        private void IncreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;

            if (int.TryParse(textBlock.Text, out int value))
            {
                value++;
                if (value > 10)
                    value = 10;
                textBlock.Text = value.ToString();
            }
        }

        private void DecreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;

            if (int.TryParse(textBlock.Text, out int value))
            {
                value--;
                if (value < 0)
                    value = 0;
                textBlock.Text = value.ToString();
            }
        }
    }
}
