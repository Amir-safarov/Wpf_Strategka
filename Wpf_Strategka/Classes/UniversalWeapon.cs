using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Strategka.Classes
{
    public enum WeaponRarity
    {
        Common, 
        Rare,   
        Epic   
    }
    public partial class UniversalWeapon
    {
        private string _weaponName;
        private double _hpUp;
        private double _manaUp;
        private double _strUp;
        private double _dexUp;
        private double _intlUp;
        private double _physDmgUp;
        private double _ccUp;
        private double _cdUp;
        public UniversalWeapon(string weaponName,double hpUp, double manaUp, double strUp, double dexUp, double intlUp, double physDmgUp, double ccUp, double cdUp)
        {
            WeaponName = weaponName;
            HpUp = hpUp;
            ManaUp = manaUp;
            StrUp = strUp;
            DexUp = dexUp;
            IntlUp = intlUp;
            PhysDmgUp = physDmgUp;
            CCUp = ccUp;
            CDUp = cdUp;
        }

        public string WeaponName { get { return _weaponName; } set { _weaponName = value; } }
        public double HpUp {  get { return _hpUp; } set {  _hpUp = value; } }
        public double ManaUp {  get { return _manaUp; } set { _manaUp = value; } }
        public double StrUp {  get { return _strUp; } set { _strUp = value; } }
        public double DexUp {  get { return _dexUp; } set {  _dexUp = value; } }
        public double IntlUp {  get { return _intlUp; } set {  _intlUp = value; } }
        public double PhysDmgUp {  get { return _physDmgUp; } set { _physDmgUp = value; } }
        public double CCUp {  get { return _ccUp; } set {  _ccUp = value; } }
        public double CDUp {  get { return _cdUp; } set {  _cdUp = value; } }

    }
}
