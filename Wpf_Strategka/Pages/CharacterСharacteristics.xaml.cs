using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf_Strategka.Classes;
using Wpf_Strategka.Constants;

namespace Wpf_Strategka.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterСharacteristics.xaml
    /// </summary>
    public partial class CharacterСharacteristics : Page
    {
        ClassesInfo info = new ClassesInfo();
        const string Warrior = "Warrior";
        const string Rogue = "Rogue";
        const string Wizard = "Wizard";

        int unitStrength;
        int unitDexterity;
        int unitInteligence;
        int unitVitality;
        int currentOD;

        public CharacterСharacteristics()
        {
            InitializeComponent();
            string imagePath = info.heroImages[App.className];
            ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            SetStartCharacteristik();
            CharacterClassIMG.Source = imageSource;
            HeroInfo.Text = info.heroInfo[App.className];
            StatsInfo.Text = info.statsInfo[App.className];
            currentOD = int.Parse(CurrentScoreTB.Text);
        }
        private void SetStartCharacteristik()
        {
            switch (App.className)
            {
                case (Warrior):
                    unitStrength = ClassesInfo.warriorCurrentStats[0];
                    unitDexterity = ClassesInfo.warriorCurrentStats[1];
                    unitInteligence = ClassesInfo.warriorCurrentStats[2];
                    unitVitality = ClassesInfo.warriorCurrentStats[3];
                    break;
                case (Rogue):
                    unitStrength = ClassesInfo.rogueCurrentStats[0];
                    unitDexterity = ClassesInfo.rogueCurrentStats[1];
                    unitInteligence = ClassesInfo.rogueCurrentStats[2];
                    unitVitality = ClassesInfo.rogueCurrentStats[3];
                    break;
                case (Wizard):
                    unitStrength = ClassesInfo.wizardCurrentStats[0];
                    unitDexterity = ClassesInfo.wizardCurrentStats[1];
                    unitInteligence = ClassesInfo.wizardCurrentStats[2];
                    unitVitality = ClassesInfo.wizardCurrentStats[3];
                    break;
            }
            UninversalClass unit = new UninversalClass(App.className, "Igot", unitStrength, unitDexterity, unitInteligence, unitVitality);

            unit.ShowUnfo();

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

        private void Refresh(TextBlock textBlock)
        {
            string tbName = textBlock.Name;
            int tbCount = int.Parse(textBlock.Text);

            switch (tbName)
            {
                case ("StrengthTB"):
                    unitStrength += tbCount;
                    break;
                case ("DexterityTB"):
                    break;
                case ("InteligenceTB"):
                    break;
                case ("VitalityTB"):
                    break;
                default:
                    break;
            }
        }
    }
}
