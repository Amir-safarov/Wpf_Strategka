using System.Windows;
using Wpf_Strategka.Classes;

namespace Wpf_Strategka
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UninversalClass uninversalClass;
        public static UniversalWeapon uninversalWeapon;
        public static UniversalEqup uninversalEqup;
        public static int playerLVL;
        public static WeaponRarity weaponRare = WeaponRarity.Common;
    }
}
