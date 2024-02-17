using System.Windows.Markup;

namespace Wpf_Strategka.Classes
{
    public partial class UniversalEqup
    {
        private string _equpName;
        private double _armorBuff;
        private double _manaBuff;
        private double _intlBuff;
        private double _hpBuff;
        private double _dexBuff;
        private double _strBuff;
        private double _strReq;
        private double _vitReq;
        private int _overLVLReq;

        public UniversalEqup(string equpName, double armorBuff, double manaBuff, double intlBuff,
            double hpBuff, double dexBuff, double strBuff, double strReq, double vitReq, int overLVLReq)
        {
            EqupName = equpName;
            ArmorBuff = armorBuff;
            ManaBuff = manaBuff;
            IntlBuff = intlBuff;
            HpBuff = hpBuff;
            DexBuff = dexBuff;
            StrBuff = strBuff;
            StrReq = strReq;
            VitReq = vitReq;
            OverLVLReq = overLVLReq;
        }

        public string EqupName { get { return _equpName; } set { _equpName = value; } }
        public double ArmorBuff
        {
            get { return _armorBuff; }
            set { _armorBuff = value; }
        }

        public double ManaBuff
        {
            get { return _manaBuff; }
            set { _manaBuff = value; }
        }

        public double IntlBuff
        {
            get { return _intlBuff; }
            set { _intlBuff = value; }
        }

        public double HpBuff
        {
            get { return _hpBuff; }
            set { _hpBuff = value; }
        }

        public double DexBuff
        {
            get { return _dexBuff; }
            set { _dexBuff = value; }
        }

        public double StrBuff
        {
            get { return _strBuff; }
            set { _strBuff = value; }
        }

        public double StrReq
        {
            get { return _strReq; }
            set { _strReq = value; }
        }

        public double VitReq
        {
            get { return _vitReq; }
            set { _vitReq = value; }
        }

        public int OverLVLReq
        {
            get { return _overLVLReq; }
            set { _overLVLReq = value; }
        }

    }
}
