using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Wpf_Strategka.Classes;
using Wpf_Strategka.Constants;

namespace Wpf_Strategka.Pages
{
    public partial class CharacterСharacteristics : Page
    {

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

        public CharacterСharacteristics(UninversalClass selectedClass)
        {
            TempStats.SaveCurrentStats();
            InitializeComponent();
            UpdateUIFromCharacteristics();
            string imagePath = ClassesInfo.heroImages[App.uninversalClass.ClassName];
            ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            CharacterClassIMG.Source = imageSource;
            StatsInfo.Text = info.statsInfo[App.uninversalClass.ClassName];
            LevelInfo.Text = info.levelInfo;
            SetStartedValues();
            ShowInfo();
        }

        private void UpdateUIFromCharacteristics()
        {
            StrengthTB.Text = App.uninversalClass.Strength.ToString();
            DexterityTB.Text = App.uninversalClass.Dexterity.ToString();
            InteligenceTB.Text = App.uninversalClass.Inteligence.ToString();
            VitalityTB.Text = App.uninversalClass.Vitality.ToString();
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
            App.uninversalClass.Strength = int.Parse(StrengthTB.Text);
            App.uninversalClass.Dexterity = int.Parse(DexterityTB.Text);
            App.uninversalClass.Inteligence = int.Parse(InteligenceTB.Text);
            App.uninversalClass.Vitality = int.Parse(VitalityTB.Text);
        }

        private void ShowInfo()
        {
            HeroInfo.Text = $"Class: {App.uninversalClass.ClassName}\nName: {App.uninversalClass.Name}\n" +
                $"Strength: {App.uninversalClass.Strength} / {App.uninversalClass.MaxStrength}" +
                $"\nDexterity: {App.uninversalClass.Dexterity} / {App.uninversalClass.MaxDexterity}\n" +
                $"Inteligence: {App.uninversalClass.Inteligence} / {App.uninversalClass.MaxInteligence}\n" +
                $"Vitality: {App.uninversalClass.Vitality}/{App.uninversalClass.MaxVitality}\n";

            HeroStats.Text = $"Health: {App.uninversalClass.Health}\nArmor: {App.uninversalClass.Armor}\n " +
                $"Mana: {App.uninversalClass.Mana}\nPhysical Damage: {App.uninversalClass.PhysicalDamage}\n" +
                $"Magic Damage: {App.uninversalClass.MagicDamage}\nMagic Defense: {App.uninversalClass.MagicDefense}\n" +
                $"Crit Chanse: {App.uninversalClass.CritChanse}\nCrit Damage: {App.uninversalClass.CritDamage}";
        }
        private void SetStartedValues()
        {
            startedStr = App.uninversalClass.Strength;
            startedIntl = App.uninversalClass.Inteligence;
            startedDex = App.uninversalClass.Dexterity;
            startedVit = App.uninversalClass.Vitality;
        }

        private double GetMaxValueForTextBlock(TextBlock textBlock)
        {
            switch (textBlock.Name)
            {
                case "StrengthTB":
                    return App.uninversalClass.MaxStrength;
                case "DexterityTB":
                    return App.uninversalClass.MaxDexterity;
                case "InteligenceTB":
                    return App.uninversalClass.MaxInteligence;
                case "VitalityTB":
                    return App.uninversalClass.MaxVitality;
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
                App.playerLVL = 2;
                ScoreCountUp();
                isSecondLvl = true;
            }
            if (currentExp >= 3000 && !isThirdLvl)
            {
                LevelTB.Text = 3.ToString();
                ScoreCountUp();
                App.playerLVL = 3;
                isThirdLvl = true;
            }
            if (currentExp >= 6000 && !isFourthLvl)
            {
                LevelTB.Text = 4.ToString();
                ScoreCountUp();
                App.playerLVL = 4;
                isFourthLvl = true;
            }
            if (currentExp >= 10000 && !isFifthLvl)
            {
                LevelTB.Text = 5.ToString();
                ScoreCountUp();
                App.playerLVL = 5;
                isFifthLvl = true;
            }
            if (currentExp >= 15000 && !isSixthLvl)
            {
                LevelTB.Text = 6.ToString();
                ScoreCountUp();
                App.playerLVL = 6;
                isSixthLvl = true;
            }
            if (currentExp >= 21000 && !isSeventhLvl)
            {
                LevelTB.Text = 7.ToString();
                ScoreCountUp();
                App.playerLVL = 7;
                isSeventhLvl = true;
            }
            if (currentExp >= 28000 && !isEighthLvl)
            {
                LevelTB.Text = 8.ToString();
                ScoreCountUp();
                App.playerLVL = 8;
                isEighthLvl = true;
            }
            if (currentExp >= 36000 && !isNinthLvl)
            {
                LevelTB.Text = 9.ToString();
                ScoreCountUp();
                App.playerLVL = 9;
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
            App.uninversalWeapon = info.weaponCoefficient[selectedWeapon];
            App.uninversalClass.CalculateStats(App.uninversalWeapon);
            SetWeaponType(App.uninversalWeapon);
            WeaponRarityTB.Text = $"Оружие: ({App.weaponRare})";
            OpenWeaponRarity();
            ShowInfo();
        }

        private void OpenWeaponRarity()
        {
            RareRarity.IsEnabled = true;
            CommonRarity.IsEnabled = true;
            EpicRarity.IsEnabled = true;
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
            TempStats.GetOldValues();

            if (sender is CheckBox checkBox)
            {
                if (checkBox.IsChecked == true)
                {
                    Shield.IsChecked = false;
                    App.uninversalClass.CalculateStats(App.uninversalWeapon, false, true);
                }
                else
                {
                    Shield.IsChecked = false;
                    App.uninversalClass.CalculateStats(App.uninversalWeapon, false, false);
                }
            }
            ShowInfo();
        }

        private void Shield_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            if (sender is CheckBox checkBox)
            {
                if (checkBox.IsChecked == true)
                {
                    TwoHeaden.IsChecked = false;
                    App.uninversalClass.CalculateStats(App.uninversalWeapon, true, false);
                }
                else
                {
                    TwoHeaden.IsChecked = false;
                    App.uninversalClass.CalculateStats(App.uninversalWeapon, false, false);
                }
            }
            ShowInfo();
        }

        private void CommonRarity_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            App.weaponRare = WeaponRarity.Common;
            if (App.uninversalWeapon != null)
                App.uninversalClass.CalculateStats(App.uninversalWeapon);
            WeaponRarityTB.Text = $"Оружие: ({App.weaponRare})";
            ShowInfo();
        }

        private void RareRarity_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            App.weaponRare = WeaponRarity.Rare;
            App.uninversalClass.CalculateStats(App.uninversalWeapon);
            WeaponRarityTB.Text = $"Оружие: ({App.weaponRare})";
            ShowInfo();
        }

        private void EpicRarity_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            App.weaponRare = WeaponRarity.Epic;
            App.uninversalClass.CalculateStats(App.uninversalWeapon);
            WeaponRarityTB.Text = $"Оружие: ({App.weaponRare})";
            ShowInfo();
        }

        private void TwoWeapon_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            Shield.IsChecked = false;
            App.uninversalClass.CalculateStats(App.uninversalWeapon, true, false);
            ShowInfo();
        }

        private void NextBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EquipmentPage());
        }
    }
}
