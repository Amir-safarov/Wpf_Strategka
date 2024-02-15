using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Wpf_Strategka.Classes;
using Wpf_Strategka.Constants;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;

namespace Wpf_Strategka.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharacterСharacteristics.xaml
    /// </summary>
    public partial class CharacterСharacteristics : Page
    {
        private UninversalClass selectedClass;
        private UniversalWeapon universalWeapon;

        private ClassesInfo info = new ClassesInfo();
        int currentPoint;
        int currentPointWithoutWeaponRarity;
        private bool isSecondLvl;
        private bool isThirdLvl;
        private bool isFourthLvl;
        private bool isFifthLvl;
        private bool isSixthLvl;
        private bool isSeventhLvl;
        private bool isEighthLvl;
        private bool isNinthLvl;

        private double startedStr;
        private double startedDex;
        private double startedIntl;
        private double startedVit;

        public CharacterСharacteristics(UninversalClass uninversalClass)
        {
            InitializeComponent();

            selectedClass = uninversalClass;
            App.uninversalClass = uninversalClass;
            string imagePath = info.heroImages[selectedClass.ClassName];
            ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            CharacterClassIMG.Source = imageSource;
            StatsInfo.Text = info.statsInfo[selectedClass.ClassName];
            LevelInfo.Text = info.levelInfo;
            CommonRarity.IsChecked = true;
            SetStartedValues();
            UpdateUIFromCharacteristics();
            ShowInfo();
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
                if (value < maxValue && currentPoint > 0)
                {
                    value++;
                    textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                    UpdateCharacteristicsFromUI();
                    currentPoint--;
                    currentPointWithoutWeaponRarity = currentPoint;
                    CurrentScoreTB.Text = currentPointWithoutWeaponRarity.ToString();
                    ShowInfo();
                }
            }
        }

        private void DecreaseValue(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)button.Tag;
            double maxValue = GetMaxValueForTextBlock(textBlock);
            double minValue = GetMinValueForTextBlock(textBlock);

            if (int.TryParse(textBlock.Text, out int value))
            {
                if (value > minValue)
                {
                    value--;
                    textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                    UpdateCharacteristicsFromUI();
                    if (value >= minValue)
                        currentPoint++;
                    currentPointWithoutWeaponRarity = currentPoint;
                    CurrentScoreTB.Text = currentPointWithoutWeaponRarity.ToString();
                    ShowInfo();
                }
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
            UpdateCharacteristicsFromUI();
            HeroInfo.Text = $"Class: {selectedClass.ClassName}\nName: {selectedClass.Name}\n" +
                $"Strength: {selectedClass.Strength} / {selectedClass.MaxStrength}" +
                $"\nDexterity: {selectedClass.Dexterity} / {selectedClass.MaxDexterity}\n" +
                $"Inteligence: {selectedClass.Inteligence} / {selectedClass.MaxInteligence}\n" +
                $"Vitality: {selectedClass.Vitality}/{selectedClass.MaxVitality}\n";

            HeroStats.Text = $"Health: {selectedClass.Health}\nArmor: {selectedClass.Armor}\n " +
                $"Mana: {selectedClass.Mana}\nPhysical Damage: {selectedClass.PhysicalDamage}\n" +
                $"Magic Damage: {selectedClass.MagicDamage}\nMagic Defense: {selectedClass.MagicDefense}\n" +
                $"Crit Chanse: {selectedClass.CritChanse}\nCrit Damage: {selectedClass.CritDamage}";
        }
        private void SetStartedValues()
        {
            startedStr = selectedClass.Strength;
            startedIntl = selectedClass.Inteligence;
            startedDex = selectedClass.Dexterity;
            startedVit = selectedClass.Vitality;
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

        private double GetMinValueForTextBlock(TextBlock textBlock)
        {
            switch (textBlock.Name)
            {
                case "StrengthTB":
                    return startedStr;
                case "DexterityTB":
                    return startedDex;
                case "InteligenceTB":
                    return startedIntl;
                case "VitalityTB":
                    return startedVit;
                default:
                    return 0;
            }
        }

        private int LimitValue(int value, int maxValue)
        {
            return Math.Max(0, Math.Min(value, (int)maxValue));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChoosingCharactersClass());
        }

        private void ExpUP_Click(object sender, RoutedEventArgs e)
        {
            int currentExp = int.Parse(CurrentExp.Text);
            Button button = sender as Button;
            if (button != null)
            {
                int buttonExpCount = int.Parse(button.Content.ToString());
                currentExp += buttonExpCount;
                LevelUpCheck(currentExp);
                CurrentExp.Text = currentExp.ToString();
            }
        }
        private void LevelUpCheck(int currentExp)
        {
            if (currentExp >= 1000 && !isSecondLvl)
            {
                LevelTB.Text = 2.ToString();
                ScoreCountUp();
                isSecondLvl = true;
            }
            if (currentExp >= 3000 && !isThirdLvl)
            {
                LevelTB.Text = 3.ToString();
                ScoreCountUp();
                isThirdLvl = true;
            }
            if (currentExp >= 6000 && !isFourthLvl)
            {
                LevelTB.Text = 4.ToString();
                ScoreCountUp();
                isFourthLvl = true;
            }
            if (currentExp >= 10000 && !isFifthLvl)
            {
                LevelTB.Text = 5.ToString();
                ScoreCountUp();
                isFifthLvl = true;
            }
            if (currentExp >= 15000 && !isSixthLvl)
            {
                LevelTB.Text = 6.ToString();
                ScoreCountUp();
                isSixthLvl = true;
            }
            if (currentExp >= 21000 && !isSeventhLvl)
            {
                LevelTB.Text = 7.ToString();
                ScoreCountUp();
                isSeventhLvl = true;
            }
            if (currentExp >= 28000 && !isEighthLvl)
            {
                LevelTB.Text = 8.ToString();
                ScoreCountUp();
                isEighthLvl = true;
            }
            if (currentExp >= 36000 && !isNinthLvl)
            {
                LevelTB.Text = 9.ToString();
                ScoreCountUp();
                isNinthLvl = true;
            }
        }

        private void ScoreCountUp()
        {
            currentPoint = int.Parse(CurrentScoreTB.Text);
            currentPoint += 25;
            currentPointWithoutWeaponRarity = currentPoint;
            CurrentScoreTB.Text = currentPointWithoutWeaponRarity.ToString();
        }

        private void WeaponCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock selectedTextBlock = (TextBlock)WeaponCB.SelectedItem;
            string selectedWeapon = selectedTextBlock.Text;
            universalWeapon = info.weaponCoefficient[selectedWeapon];
            selectedClass.CalculateStats(universalWeapon);
            SetWeaponType(universalWeapon);
            WeaponRarityTB.Text = $"Оружие: ({App.weaponRare})";
            ShowInfo();
        }
        private void SetWeaponType(UniversalWeapon selectedWeapon)
        {
            DropCheckBoxValues();
            if (selectedWeapon.WeaponName == "Palka" || selectedWeapon.WeaponName == "Sword"
                || selectedWeapon.WeaponName == "Axe" || selectedWeapon.WeaponName == "Hammer")
            {
                TwoHeaden.IsEnabled = true;
                Shield.IsEnabled = true;
                TwoWeapon.IsEnabled = false;
            }
            if (selectedWeapon.WeaponName == "Dagger")
            {
                TwoHeaden.IsEnabled = false;
                Shield.IsEnabled = false;
                TwoWeapon.IsEnabled = true;
            }
        }

        private void DropCheckBoxValues()
        {
            TwoHeaden.IsChecked = false;
            Shield.IsChecked = false;
            TwoWeapon.IsChecked = false;
        }

        private void TwoHeaden_Checked(object sender, RoutedEventArgs e)
        {
            Shield.IsChecked = false;
            selectedClass.CalculateStats(universalWeapon, false, true);
            ShowInfo();
        }

        private void Shield_Checked(object sender, RoutedEventArgs e)
        {
            TwoHeaden.IsChecked = false;
            selectedClass.CalculateStats(universalWeapon, true, false);
            ShowInfo();
        }

        private void CommonRarity_Checked(object sender, RoutedEventArgs e)
        {
            App.weaponRare = WeaponRarity.Common;
        }

        private void RareRarity_Checked(object sender, RoutedEventArgs e)
        {
            App.weaponRare = WeaponRarity.Rare;
        }

        private void EpicRarity_Checked(object sender, RoutedEventArgs e)
        {
            App.weaponRare = WeaponRarity.Epic;
        }

        private void TwoWeapon_Checked(object sender, RoutedEventArgs e)
        {
            Shield.IsChecked = false;
            selectedClass.CalculateStats(universalWeapon, true, false);
            ShowInfo();
        }
    }
}
