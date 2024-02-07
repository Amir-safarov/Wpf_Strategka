﻿using System;
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
        private ClassesInfo info = new ClassesInfo();
        int currentPoint;
        public CharacterСharacteristics(UninversalClass uninversalClass)
        {
            InitializeComponent();

            selectedClass = uninversalClass;
            string imagePath = info.heroImages[selectedClass.ClassName];
            ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            CharacterClassIMG.Source = imageSource;
            StatsInfo.Text = info.statsInfo[selectedClass.ClassName];
            LevelInfo.Text = info.levelInfo;
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
                if (value < maxValue && currentPoint > 0)
                {
                    value++;
                    textBlock.Text = LimitValue(value, (int)maxValue).ToString();
                    UpdateCharacteristicsFromUI();
                    currentPoint--;
                    CurrentScoreTB.Text = currentPoint.ToString();
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
            selectedClass.CalculateStats();
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
                    return selectedClass.Strength;
                case "DexterityTB":
                    return selectedClass.Dexterity;
                case "InteligenceTB":
                    return selectedClass.Inteligence;
                case "VitalityTB":
                    return selectedClass.Vitality;
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
            List<int> levels = new List<int>{1000, 3000, 6000, 10000, 15000, 21000, 28000, 36000};

            int currentLevel = int.Parse(LevelTB.Text);
            for (int i = 0; i < levels.Count; i++)
            {
                if (currentExp >= levels[i])
                {
                    //currentLevel += 1;
                    levels.Remove(i);
                }
                else
                {
                    break; 
                }
            }
            LevelTB.Text = currentLevel.ToString();
        }
    }
}
