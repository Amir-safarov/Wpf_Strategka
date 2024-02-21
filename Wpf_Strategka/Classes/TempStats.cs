namespace Wpf_Strategka.Classes
{
    internal static class TempStats
    {
        private static double _saveStrength;
        private static double _saveDexterity;
        private static double   _saveInteligence;
        private static double _saveVitality;
        private static double _saveHealth;
        private static double _saveMana;

        private static double _savePhysicalDamage;
        private static double _saveArmor;
        private static double _saveMagicDamage;
        private static double _saveMagicDefense;
        private static double _saveCritChanse;
        private static double _saveCritDamage;

        public static void SaveCurrentStats()
        {
            _saveStrength = App.uninversalClass.Strength;
            _saveDexterity = App.uninversalClass.Dexterity;
            _saveInteligence = App.uninversalClass.Inteligence;
            _saveVitality = App.uninversalClass.Vitality;
            _saveHealth = App.uninversalClass.Health;
            _saveMana = App.uninversalClass.Mana;

            _savePhysicalDamage = App.uninversalClass.PhysicalDamage;
            _saveArmor = App.uninversalClass.Armor;
            _saveMagicDamage = App.uninversalClass.MagicDamage;
            _saveMagicDefense = App.uninversalClass.MagicDefense;
            _saveCritChanse = App.uninversalClass.CritChanse;
            _saveCritDamage = App.uninversalClass.CritDamage;

        }
        public static void GetOldValues()
        {
            App.uninversalClass.Strength = _saveStrength;
            App.uninversalClass.Dexterity = _saveDexterity;
            App.uninversalClass.Inteligence = _saveInteligence;
            App.uninversalClass.Vitality = _saveVitality;
            App.uninversalClass.Health = _saveHealth;
            App.uninversalClass.Mana = _saveMana;

            App.uninversalClass.PhysicalDamage = _savePhysicalDamage;
            App.uninversalClass.Armor = _saveArmor;
            App.uninversalClass.MagicDamage = _saveMagicDamage;
            App.uninversalClass.MagicDefense = _saveMagicDefense;
            App.uninversalClass.CritChanse = _saveCritChanse;
            App.uninversalClass.CritDamage = _saveCritDamage;
        }
    }
}
