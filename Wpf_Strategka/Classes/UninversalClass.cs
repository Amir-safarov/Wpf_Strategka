using System;
using System.Windows;
using Wpf_Strategka.Constants;
using Wpf_Strategka.Pages;

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

        private double _saveStrength;
        private double _saveDexterity;
        private double _saveInteligence;
        private double _saveVitality;
        private double _saveHealth;
        private double _saveMana;

        private double _savePhysicalDamage;
        private double _saveArmor;
        private double _saveMagicDamage;
        private double _saveMagicDefense;
        private double _saveCritChanse;
        private double _saveCritDamage;

        public UninversalClass(string className, string name, double strength, double maxStrength, double dexterity, double maxDexterity, double inteligence, double maxInteligence, double vitality, double maxVitality)
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
            CalculateStats();
        }

        public void SaveCurrentStats()
        {
            _saveStrength = Strength;
            _saveDexterity = Dexterity;
            _saveInteligence = Inteligence;
            _saveVitality = Vitality;
            _saveHealth = Health;
            _saveMana = Mana;

            _savePhysicalDamage = PhysicalDamage;
            _saveArmor = Armor;
            _saveMagicDamage = MagicDamage;
            _saveMagicDefense = MagicDefense;
            _saveCritChanse = CritChanse;
            _saveCritDamage = CritDamage;

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
        public double Inteligence { get { return Math.Round(_inteligence, 2); } set { _inteligence = value; } }
        public double MaxInteligence { get { return _maxInteligence; } private set { _maxInteligence = value; } }
        public double Vitality { get { return _vitality; } set { _vitality = value; } }
        public double MaxVitality { get { return _maxVitality; } private set { _maxVitality = value; } }

        public double Health { get { return _health; } set { _health = value; } }
        public double Mana { get { return _mana; } set { _mana = value; } }
        public double PhysicalDamage { get { return _physicalDamage; } set { _physicalDamage = value; } }
        public double Armor { get { return _armor; } set { _armor = value; } }
        public double MagicDamage { get { return _magicDamage; } set { _magicDamage = value; } }
        public double MagicDefense { get { return _magicDefense; } set { _magicDefense = value; } }
        public double CritChanse { get { return _critChanse; } set { _critChanse = value; } }
        public double CritDamage { get { return _critDamage; } set { _critDamage = value; } }

        public void CalculateStatsWithEqup(bool isOneRing, bool isTwoRing, bool isAmulet, bool isHelmet)
        {
            if (App.uninversalEqup != null)
            {
                CalculateStatsWithEqup();
                if (isOneRing)
                    Mana *= 1.05;
                if (isTwoRing)
                    Mana *= 1.15;
                if (isHelmet)
                    Armor *= 1.2;
                if (isAmulet)
                {
                    Inteligence *= 1.1;
                    Mana *= Inteligence / 4;
                    MagicDefense *= 1.1;
                }

            }
        }
        private void CalculateStatsWithEqup()
        {
            if (App.equpRare == WeaponRarity.Common)
            {
                if (App.uninversalEqup.ArmorBuff != 0)
                    Armor *= App.uninversalEqup.ArmorBuff;
            }
            if (App.equpRare == WeaponRarity.Rare)
            {
                if (App.uninversalEqup.ArmorBuff != 0)
                    Armor *= App.uninversalEqup.ArmorBuff;
                if (App.uninversalEqup.ManaBuff != 0)
                    Mana *= App.uninversalEqup.ManaBuff;
                if (App.uninversalEqup.IntlBuff != 0)
                    Inteligence *= App.uninversalEqup.IntlBuff;
                if (App.uninversalEqup.DexBuff != 0)
                    Dexterity *= App.uninversalEqup.DexBuff;
                if (App.uninversalEqup.StrBuff != 0)
                    Strength *= App.uninversalEqup.StrBuff;
            }
            if (App.equpRare == WeaponRarity.Epic)
            {
                if (App.uninversalEqup.ArmorBuff != 0)
                    Armor *= App.uninversalEqup.ArmorBuff;
                if (App.uninversalEqup.ManaBuff != 0)
                    Mana *= App.uninversalEqup.ManaBuff;
                if (App.uninversalEqup.IntlBuff != 0)
                    Inteligence *= App.uninversalEqup.IntlBuff;
                if (App.uninversalEqup.DexBuff != 0)
                    Dexterity *= App.uninversalEqup.DexBuff;
                if (App.uninversalEqup.StrBuff != 0)
                    Strength *= App.uninversalEqup.StrBuff;
                if (App.uninversalEqup.HpBuff != 0)
                    Health *= App.uninversalEqup.HpBuff;
            }
        }

        public void GetOldValues()
        {
            Strength = _saveStrength;
            Dexterity = _saveDexterity;
            Inteligence = _saveInteligence;
            Vitality = _saveVitality;
            Health = _saveHealth;
            Mana = _saveMana;

            PhysicalDamage = _savePhysicalDamage;
            Armor = _saveArmor;
            MagicDamage = _saveMagicDamage;
            MagicDefense = _saveMagicDefense;
            CritChanse = _saveCritChanse;
            CritDamage = _saveCritDamage;
        }

        public void CalculateStats()
        {
            Health = coefficient[0] * Vitality + coefficient[1] * Strength;
            Mana = coefficient[2] * Inteligence;
            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
            Armor = coefficient[5] * Dexterity;
            MagicDamage = coefficient[6] * Inteligence;
            MagicDefense = coefficient[7] * Inteligence;
            CritChanse = coefficient[8] * Dexterity;
            CritDamage = coefficient[9] * Dexterity;
        }
        public void CalculateStats(UniversalWeapon selectedWeapon, bool shieldOn, bool twoHeandOn)
        {
            if (shieldOn)
            {
                if (selectedWeapon.WeaponName == "Palka" && App.uninversalClass.ClassName == "Wizard")
                {
                    if (App.weaponRare == WeaponRarity.Common)
                    {
                        Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        Mana = (coefficient[2] * Inteligence);
                        PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity + 15;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        CritChanse = (coefficient[8] * Dexterity);
                        CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Rare)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity + 15;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp;
                        else
                            CritChanse = (coefficient[8] * Dexterity);
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp;
                        else
                            CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Epic)
                    {

                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity + 15;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        CritChanse = (coefficient[8] * Dexterity) * 1.05;
                        CritDamage = (coefficient[9] * Dexterity) * 3;
                    }
                }
                else
                {
                    if (App.weaponRare == WeaponRarity.Common)
                    {
                        Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        Mana = (coefficient[2] * Inteligence);
                        PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity + 15;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp;
                        else
                            CritChanse = (coefficient[8] * Dexterity);
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp;
                        else
                            CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Rare)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity + 15;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp;
                        else
                            CritChanse = (coefficient[8] * Dexterity);
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp;
                        else
                            CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Epic)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity + 15;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp;
                        else
                            CritChanse = (coefficient[8] * Dexterity);
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp;
                        else
                            CritDamage = coefficient[9] * Dexterity;
                    }
                }
            }
            if (twoHeandOn)
            {
                if (selectedWeapon.WeaponName == "Palka" && App.uninversalClass.ClassName == "Wizard")
                {
                    if (App.weaponRare == WeaponRarity.Common)
                    {
                        Health = (coefficient[0] * Vitality + coefficient[1] * Strength) *1.7;
                        Mana = (coefficient[2] * Inteligence) * 1.7;
                        PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity * 1.7;
                        Armor = coefficient[5] * Dexterity * 1.7;
                        MagicDamage = coefficient[6] * Inteligence * 1.7;
                        MagicDefense = coefficient[7] * Inteligence * 1.7;
                        CritChanse = (coefficient[8] * Dexterity) * 1.7;
                        CritDamage = coefficient[9] * Dexterity * 1.7;
                    }
                    if (App.weaponRare == WeaponRarity.Rare)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp * 1.7;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * 1.7;
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp * 1.7;
                        else
                            Mana = (coefficient[2] * Inteligence) * 1.7;
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp * 1.7;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity * 1.7;
                        Armor = coefficient[5] * Dexterity * 1.7;
                        MagicDamage = coefficient[6] * Inteligence * 1.7;
                        MagicDefense = coefficient[7] * Inteligence * 1.7;
                    }
                    if (App.weaponRare == WeaponRarity.Epic)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp * 1.7;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * 1.7;
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp * 1.7;
                        else
                            Mana = (coefficient[2] * Inteligence) * 1.7;
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp * 1.7;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity * 1.7;
                        Armor = coefficient[5] * Dexterity * 1.7;
                        MagicDamage = coefficient[6] * Inteligence * 1.7;
                        MagicDefense = coefficient[7] * Inteligence * 1.7;
                        CritChanse = (coefficient[8] * Dexterity) * 1.05;
                        CritDamage = (coefficient[9] * Dexterity) * 3;
                    }
                }
                else
                {
                    if (App.weaponRare == WeaponRarity.Common)
                    {
                        Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * 1.7;
                        Mana = (coefficient[2] * Inteligence) * 1.7;
                        PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity * 1.7;
                        Armor = coefficient[5] * Dexterity * 1.7;
                        MagicDamage = coefficient[6] * Inteligence * 1.7;
                        MagicDefense = coefficient[7] * Inteligence * 1.7;
                        CritChanse = (coefficient[8] * Dexterity) * 1.7;
                        CritDamage = coefficient[9] * Dexterity * 1.7;
                    }
                    if (App.weaponRare == WeaponRarity.Rare)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp * 1.7;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * 1.7;
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp * 1.7;
                        else
                            Mana = (coefficient[2] * Inteligence) * 1.7;
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp * 1.7;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity * 1.7;
                        Armor = coefficient[5] * Dexterity * 1.7;
                        MagicDamage = coefficient[6] * Inteligence * 1.7;
                        MagicDefense = coefficient[7] * Inteligence * 1.7;
                    }
                    if (App.weaponRare == WeaponRarity.Epic)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp * 1.7;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * 1.7;
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp * 1.7;
                        else
                            Mana = (coefficient[2] * Inteligence) * 1.7;
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp * 1.7;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity * 1.7;
                        Armor = coefficient[5] * Dexterity * 1.7;
                        MagicDamage = coefficient[6] * Inteligence * 1.7;
                        MagicDefense = coefficient[7] * Inteligence * 1.7;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp * 1.7;
                        else
                            CritChanse = (coefficient[8] * Dexterity) * 1.7;
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp * 1.7;
                        else
                            CritDamage = coefficient[9] * Dexterity * 1.7;
                    }
                }
            }
        }
        public void CalculateStats(UniversalWeapon selectedWeapon)
        {
            if (selectedWeapon != null)
            {
                if (selectedWeapon.WeaponName == "Palka" && App.uninversalClass.ClassName == "Wizard")
                {
                    if (App.weaponRare == WeaponRarity.Common)
                    {
                        Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        Mana = (coefficient[2] * Inteligence);
                        PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        CritChanse = (coefficient[8] * Dexterity);
                        CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Rare)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp;
                        else
                            CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Epic)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp;
                        else
                            CritChanse = (coefficient[8] * Dexterity);
                        CritChanse = (coefficient[8] * Dexterity) * 1.05;
                        CritDamage = (coefficient[9] * Dexterity) * 3;
                    }
                }
                else
                {
                    if (App.weaponRare == WeaponRarity.Common)
                    {
                        Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        Mana = (coefficient[2] * Inteligence);
                        PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        CritChanse = (coefficient[8] * Dexterity);
                        CritDamage = coefficient[9] * Dexterity;
                    }
                    if (App.weaponRare == WeaponRarity.Rare)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                    }
                    if (App.weaponRare == WeaponRarity.Epic)
                    {
                        if (selectedWeapon.HpUp != 0)
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength) * selectedWeapon.HpUp;
                        else
                            Health = (coefficient[0] * Vitality + coefficient[1] * Strength);
                        if (selectedWeapon.IntlUp != 0)
                            Mana = (coefficient[2] * Inteligence) * selectedWeapon.IntlUp;
                        else
                            Mana = (coefficient[2] * Inteligence);
                        if (selectedWeapon.PhysDmgUp != 0)
                            PhysicalDamage = (coefficient[3] * Strength + coefficient[4] * Dexterity) * selectedWeapon.PhysDmgUp;
                        else
                            PhysicalDamage = coefficient[3] * Strength + coefficient[4] * Dexterity;
                        Armor = coefficient[5] * Dexterity;
                        MagicDamage = coefficient[6] * Inteligence;
                        MagicDefense = coefficient[7] * Inteligence;
                        if (selectedWeapon.CCUp != 0)
                            CritChanse = (coefficient[8] * Dexterity) * selectedWeapon.CCUp;
                        else
                            CritChanse = (coefficient[8] * Dexterity);
                        if (selectedWeapon.CDUp != 0)
                            CritDamage = (coefficient[9] * Dexterity) * selectedWeapon.CDUp;
                        else
                            CritDamage = coefficient[9] * Dexterity;
                    }
                }
            }
        }
    }
}
