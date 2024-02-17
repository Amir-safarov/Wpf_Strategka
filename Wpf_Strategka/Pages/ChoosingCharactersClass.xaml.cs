using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
            App.uninversalClass = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string buttonText = button.Content.ToString();
                switch (buttonText)
                {
                    case "Warrior":
                        App.uninversalClass = new UninversalClass("Warrior", "", 30, 200, 15, 80, 10, 50, 25, 100); ;
                        break;
                    case "Rogue":
                        App.uninversalClass = new UninversalClass("Rogue", "", 20, 65, 30, 200, 15, 70, 20, 80);
                        break;
                    case "Wizard":
                        App.uninversalClass = new UninversalClass("Wizard", "", 15, 45, 20, 80, 35, 200, 15, 70);
                        break;
                }
                if (info.statsInfo.ContainsKey(App.uninversalClass.ClassName) && info.heroInfo.ContainsKey(buttonText))
                {
                    StatsInfo.Text = info.statsInfo[App.uninversalClass.ClassName];
                    HeroInfo.Text = $"Strength {App.uninversalClass.Strength}/{App.uninversalClass.MaxStrength}\nDexterity {App.uninversalClass.Dexterity}/{App.uninversalClass.MaxDexterity}\nIntelligence {App.uninversalClass.Inteligence}/{App.uninversalClass.MaxInteligence}\nVitality {App.uninversalClass.Vitality}/{App.uninversalClass.MaxVitality}\n";
                    string imagePath = ClassesInfo.heroImages[App.uninversalClass.ClassName];
                    ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    ClassImg.Source = imageSource;
                }
                ChosingNameSP.Visibility = Visibility.Visible;
            }

        }

        private void NextBTN_Click(object sender, RoutedEventArgs e)
        {
            if (App.uninversalClass == null || App.uninversalClass.Name == "")
                return;
            NavigationService.Navigate(new CharacterСharacteristics());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (App.uninversalClass == null)
            {
                MessageBox.Show("Сначала выберите класс");
                textBox.Text = null;
                return;
            }
            if (textBox != null)
                App.uninversalClass.Name = textBox.Text;
        }
    }
}
