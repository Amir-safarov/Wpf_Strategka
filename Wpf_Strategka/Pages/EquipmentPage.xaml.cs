using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Wpf_Strategka.Constants;
using System.Collections.Generic;
using Wpf_Strategka.Classes;
using System.Windows;

namespace Wpf_Strategka.Pages
{
    public partial class EquipmentPage : Page
    {
        private bool _oneRignEqup;
        private bool _twoRignEqup;
        private bool _amuletEqup;
        private bool _helmetEqup;
        public List<UniversalEqup> Equp { get; set; }
        public EquipmentPage()
        {
            TempStats.SaveCurrentStats();
            InitializeComponent();
            Equp = new List<UniversalEqup>
            {
            new UniversalEqup("Robe", 1.05, 1.15, 1.15, 1.05, 0, 0, 5, 5, 0),
            new UniversalEqup("Leather Armor", 1.1, 0, 0, 1.1, 1.15, 1.05, 6, 0, 0),
            new UniversalEqup("Chain Armor", 1.15, 0, 0, 1.1, 0.95, 1.1, 6,0,6),
            new UniversalEqup("Plate  Armor", 1.2, 0, 0, 1.15, 0.85, 1.15, 7,6,8),
            };

            DataContext = this;
            string imagePath = ClassesInfo.heroImages[App.uninversalClass.ClassName];
            ImageSource imageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            CharacterClassIMG.Source = imageSource;
            ShowInfo();

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

        private void EqupCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TempStats.GetOldValues();
            UniversalEqup selectedEqup = (EqupCB.SelectedItem as UniversalEqup);
            App.uninversalEqup = selectedEqup;
            if (App.uninversalClass.Strength >= selectedEqup.StrReq &&
                App.uninversalClass.Vitality >= selectedEqup.VitReq &&
                App.playerLVL >= selectedEqup.OverLVLReq)
            {
                PutOnBTN.Visibility = Visibility.Visible;
            }
            else
            {
                PutOnBTN.Visibility = Visibility.Collapsed;
            }
            ItemDiscrip.Text = ClassesInfo.equpDescript[selectedEqup.EqupName];
            REQUIREMENTSTB.Text = ShowEqupReq(selectedEqup.OverLVLReq, selectedEqup.VitReq, selectedEqup.StrReq);
        }
        private void PutOnBTN_Click(object sender, RoutedEventArgs e)
        {
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private string ShowEqupReq(int overLVLReq, double vitReq, double strReq)
        {
            return $"Уровень >{overLVLReq}.\nСила >{strReq}.\nВыносливость>{vitReq}.";
        }

        private void CommonRarity_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            App.equpRare = WeaponRarity.Common;
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private void RareRarity_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            App.equpRare = WeaponRarity.Rare;
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private void EpicRarity_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            App.equpRare = WeaponRarity.Epic;
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private void OneRingRB_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            RadioButton pressed = (RadioButton)sender;
            _oneRignEqup = (bool)pressed.IsChecked;
            _twoRignEqup = !(bool)pressed.IsChecked;
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private void TwoRingRB_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            RadioButton pressed = (RadioButton)sender;
            _twoRignEqup = (bool)pressed.IsChecked;
            _oneRignEqup = !(bool)pressed.IsChecked;
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private void AmuletRB_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            CheckBox pressed = (CheckBox)sender;
            _amuletEqup = (bool)pressed.IsChecked;
            App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            ShowInfo();
        }

        private void HelmetRB_Checked(object sender, RoutedEventArgs e)
        {
            TempStats.GetOldValues();
            CheckBox pressed = (CheckBox)sender;
            _helmetEqup = (bool)pressed.IsChecked;
            if (App.uninversalClass.Strength >= 10)
                App.uninversalClass.CalculateStatsWithEqup(_oneRignEqup, _twoRignEqup, _amuletEqup, _helmetEqup);
            else
            {
                MessageBox.Show("Персонаж не достаточно прокачен");
                pressed.IsChecked = false;
                return;
            }
            ShowInfo();
        }

    }
}
