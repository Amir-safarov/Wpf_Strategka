using System;
using System.Windows;
using System.Windows.Controls;
using Wpf_Strategka.Classes;

namespace Wpf_Strategka.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterСharacteristics.xaml
    /// </summary>
    public partial class CharacterСharacteristics : Page
    {
        private UninversalClass selectedClass;
        int currentPoint;
        public CharacterСharacteristics(UninversalClass uninversalClass)
        {
            InitializeComponent();

            selectedClass = uninversalClass;
            UpdateUIFromCharacteristics();
            ShowInfo();  // Fixed typo in the method name
            currentPoint = int.Parse(CurrentScoreTB.Text);
        }

        private void UpdateUIFromCharacteristics()
        {
            StrengthTB.Text = selectedClass.Strength.ToString();
            DexterityTB.Text = selectedClass.Dexterity.ToString();
            InteligenceTB.Text = selectedClass.Inteligence.ToString();
            VitalityTB.Text = selectedClass.Vitality.ToString();
        }

        private void IncreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;
            double maxValue = GetMaxValueForTextBlock(textBlock);

            if (int.TryParse(textBlock.Text, out int value))
            {
                if (value < maxValue && currentPoint > 0)  // Check if there are available points to spend
                {
                    value++;
                    textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                    UpdateCharacteristicsFromUI();
                    currentPoint--;
                    CurrentScoreTB.Text = currentPoint.ToString();
                    ShowInfo();  // Update info after increasing value
                }
            }
        }

        private void DecreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;
            double maxValue = GetMaxValueForTextBlock(textBlock);

            if (int.TryParse(textBlock.Text, out int value))
            {
                if (value > 0)
                    currentPoint++;
                value--;
                textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                UpdateCharacteristicsFromUI();
                CurrentScoreTB.Text = currentPoint.ToString();
                ShowInfo();
            }
        }

        private void UpdateCharacteristicsFromUI()
        {
            selectedClass.Strength = int.Parse(StrengthTB.Text);
            selectedClass.Dexterity = int.Parse(DexterityTB.Text);
            selectedClass.Inteligence = int.Parse(InteligenceTB.Text);
            selectedClass.Vitality = int.Parse(VitalityTB.Text);
        }

        private void ShowInfo()
        {
            HeroInfo.Text = $"{selectedClass.ClassName}\n{selectedClass.Name}\n{selectedClass.Strength}/{selectedClass.MaxStrength}\n{selectedClass.Dexterity}/{selectedClass.MaxDexterity}\n{selectedClass.Inteligence}/{selectedClass.MaxInteligence}\n{selectedClass.Vitality}/{selectedClass.MaxVitality}\n{selectedClass.Health}\n{selectedClass.Mana}\n{selectedClass.PhysicalDamage}\n{selectedClass.Armor}\n{selectedClass.MagicDamage}\n{selectedClass.MagicDefense}\n{selectedClass.CritChanse}\n{selectedClass.CritDamage}";  // Fixed typo in property name
        }
        private double GetMaxValueForTextBlock(TextBlock textBlock)
        {
            switch (textBlock.Name)
            {
                case "StrengthTB":
                    return selectedClass.MaxStrength;
                case "DexterityTB":
                    return selectedClass.MaxDexterity;
                case "InteligenceTB":
                    return selectedClass.MaxInteligence;
                case "VitalityTB":
                    return selectedClass.MaxVitality;
                default:
                    return 0;
            }
        }

        private int LimitValue(int value, int maxValue)
        {
            return Math.Max(0, Math.Min(value, (int)maxValue));
        }

    }
}
