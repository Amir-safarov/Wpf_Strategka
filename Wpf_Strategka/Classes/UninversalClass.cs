using System.Windows;
using Wpf_Strategka.Constants;

namespace Wpf_Strategka.Classes
{
    public partial class UninversalClass
    {
        ClassesInfo info = new ClassesInfo();
        private double[] coefficient;
        private string _className;
        private string _name;

        private double _strength;
        private double _maxStrength;
        private double _dexterity;
        private double _maxDexterity;
        private double _inteligence;
        private double _maxInteligence;
        private double _vitality;
        private double _maxVitality;
        private double _health;
        private double _mana;

        private double _physicalDamage;
        private double _armor;
        private double _magicDamage;
        private double _magicDefense;
        private double _critChanse;
        private double _critDamage;

        public UninversalClass(string className, string name, double strength, double maxStrength, double dexterity, double maxDexterity, double inteligence,double maxInteligence, double vitality, double maxVitality)
        {
            if (info.heroCoefficient.ContainsKey(className))
                coefficient = info.heroCoefficient[className];
            ClassName = className;
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Inteligence = inteligence;
            Vitality = vitality;
            MaxStrength = maxStrength;
            MaxInteligence = maxInteligence;
            MaxVitality = maxVitality;
            MaxDexterity = maxDexterity;
            Health = 0;
            Mana = 0;
            PhysicalDamage = 0;
            Armor = 0;
            MagicDamage = 0;
            MagicDefense = 0;
            CritChanse = 0;
            CritDamage = 0;
        }

        public void ShowUnfo()
        {
            MessageBox.Show($"{ClassName}\n{Name}\n{Strength}\n{Dexterity}\n{Inteligence}\n{Vitality}\n{Health}\n{Mana}\n");
        }
        public string ClassName { get { return _className; } set { _className = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public double Strength { get { return _strength; } set { _strength = value; } }
        public double MaxStrength { get { return _maxStrength; } private set { _maxStrength = value; } }
        public double Dexterity { get { return _dexterity; } set { _dexterity = value; } }
        public double MaxDexterity { get { return _maxDexterity; } private set { _maxDexterity = value; } }
        public double Inteligence { get { return _inteligence; } set { _inteligence = value; } }
        public double MaxInteligence { get { return _maxInteligence; } private set { _maxInteligence = value; } }
        public double Vitality { get { return _vitality; } set { _vitality = value; } }
        public double MaxVitality { get { return _maxVitality; } private set { _maxVitality = value; } }

        public double Health { get { return _health; } set { _health = value + (coefficient[0]*Vitality + coefficient[1] * Strength);}}
        public double Mana { get { return _mana; } set { _mana = value + (coefficient[2]*Inteligence); } }
        public double PhysicalDamage { get { return _physicalDamage; } set { _physicalDamage = value + (coefficient[3] * Strength + (coefficient[4] * Dexterity)); } }
        public double Armor { get { return _armor; } set { _armor = value+ (coefficient[5] * Dexterity); } }
        public double MagicDamage { get { return _magicDamage; } set { _magicDamage = value + (coefficient[6] *Inteligence); } }
        public double MagicDefense { get { return _magicDefense; } set { _magicDefense = value+ (coefficient[7] * Inteligence); } }
        public double CritChanse { get { return _critChanse; } set { _critChanse = value+ (coefficient[8] * Dexterity); } }
        public double CritDamage { get { return _critDamage; } set { _critDamage = value+ (coefficient[9] * Dexterity); } }
    }
}
