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
        private int _strUp;
        private int _dexUp;
        private int _intlUp;
        private double _physDmgUp;
        private double _ccUp;
        private double _cdUp;
        public UniversalWeapon(string weaponName, double physDmgUp, double manaUp, int intlUp, double ccUp, double cdUp, int strUp, int dexUp, double hpUp)
        {
            WeaponName = weaponName;
            PhysDmgUp = physDmgUp;
            ManaUp = manaUp;
            IntlUp = intlUp;
            CCUp = ccUp;
            CDUp = cdUp;
            StrUp = strUp;
            DexUp = dexUp;
            HpUp = hpUp;
        }

        public string WeaponName { get { return _weaponName; } set { _weaponName = value; } }
        public double HpUp {  get { return _hpUp; } set {  _hpUp = value; } }
        public double ManaUp {  get { return _manaUp; } set { _manaUp = value; } }
        public int StrUp {  get { return _strUp; } set { _strUp = value; } }
        public int DexUp {  get { return _dexUp; } set {  _dexUp = value; } }
        public int IntlUp {  get { return _intlUp; } set {  _intlUp = value; } }
        public double PhysDmgUp {  get { return _physDmgUp; } set { _physDmgUp = value; } }
        public double CCUp {  get { return _ccUp; } set {  _ccUp = value; } }
        public double CDUp {  get { return _cdUp; } set {  _cdUp = value; } }

    }
}
