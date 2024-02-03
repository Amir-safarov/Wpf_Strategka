using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private UninversalClass selectedClass;
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
                switch (buttonText)
                {
                    case "Warrior":
                        selectedClass = new UninversalClass("Warrior", "Artorius", 30, 200, 15, 80, 10, 50, 25, 100); ;
                        break;
                    case "Rogue":
                        selectedClass = new UninversalClass("Rogue", "Snake", 20, 65, 30, 200, 15, 70, 20, 80);
                        break;
                    case "Wizard":
                        selectedClass = new UninversalClass("Wizard", "Rudeus", 15, 45, 20, 80, 35, 200, 15, 70);
                        break;
                }
                if (info.statsInfo.ContainsKey(selectedClass.ClassName) && info.heroInfo.ContainsKey(buttonText))
                {
                    StatsInfo.Text = info.statsInfo[selectedClass.ClassName];
                    HeroInfo.Text = $"Strength {selectedClass.Strength}/{selectedClass.MaxStrength}\nDexterity {selectedClass.Dexterity}/{selectedClass.MaxDexterity}\nIntelligence {selectedClass.Inteligence}/{selectedClass.MaxInteligence}\nVitality {selectedClass.Vitality}/{selectedClass.MaxVitality}\n";
                    string imagePath = info.heroImages[selectedClass.ClassName];
                    ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                    ClassImg.Source = imageSource;

                }
            }

        }

        private void NextBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharacterСharacteristics(selectedClass));
        }
    }
}
