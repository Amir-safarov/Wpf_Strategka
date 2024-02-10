using System.Collections.Generic;
using Wpf_Strategka.Classes;

namespace Wpf_Strategka.Constants
{
    internal class ClassesInfo
    {
        internal string levelInfo = "Level\texp total\n1\t0\n2\t1000\n3\t3000\n4\t6000\n5\t10000\n6\t15000\n7\t21000\n8\t28000\n9\t36000\n";
        internal Dictionary<string, string> statsInfo = new Dictionary<string, string>(){
            {"Warrior", "Health 2/1vit , 1/str\nMana 1/1 int\np.damage 1/str\narmor 1/dex\nm.damage 0.2/int\nm.defense 05/int\ncrt.chanse 0.2/dex\ncrt.damage 0.1/dex"},
            {"Rogue", "Health 1.5/1vit 0.5/1str\nMana 1.2/int\np.damage 0.5/str+0.5dex\narmor 1.5/dex\nm.damage 0.2/int\nm.defense 0.5/int\ncrt.chanse 0.2/dex\ncrt.damage 0.1/dex\n"},
            {"Wizard", "Health 1.4/Vit 0.2/str\nMana 1.5/int\np.damage 0.5/str\narmor 1/dex\nm.damage 1/int\nm.defense 1/int\ncrt.chanse O.2/dex\ncrt.damage 0.1/dex\n"},
        };
        internal Dictionary<string, string> heroInfo = new Dictionary<string, string>(){
            {"Warrior", $"Strength {warriorCurrentStats[0]}/{warriorMaxStats[0]}\nDexterity {warriorCurrentStats[1]}/{warriorMaxStats[1]}\nIntelligence {warriorCurrentStats[2]}/{warriorMaxStats[2]}\nVitality {warriorCurrentStats[3]}/{warriorMaxStats[3]}\n"},
            {"Rogue", $"Strength {rogueCurrentStats[0]}/{rogueMaxStats[0]}\nDexterity {rogueCurrentStats[1]}/{rogueMaxStats[1]}\nIntelligence {rogueCurrentStats[2]}/{rogueMaxStats[2]}\nVitality {rogueCurrentStats[3]}/{rogueMaxStats[3]}\n"},
            {"Wizard", $"Strength {wizardCurrentStats[0]}/{wizarMaxStats[0]}\nDexterity {wizardCurrentStats[1]}/{wizarMaxStats[1]}\nIntelligence {wizardCurrentStats[2]}/{wizarMaxStats[2]}\nVitality {wizardCurrentStats[3]}/{wizarMaxStats[3]}\n"},
        };
        internal Dictionary<string, string> heroImages = new Dictionary<string, string>(){
            {"Warrior", "/Resources/warrior.png"},
            {"Rogue", "/Resources/rogue.png"},
            {"Wizard", "/Resources/wizard.png"},
        };
        internal Dictionary<string, double[]> heroCoefficient = new Dictionary<string, double[]>(){
            {"Warrior", new double[]{2,1,1,1,0,1,0.2,0.5,0.2,0.1}},
            {"Rogue", new double[]{1.5,0.5,1.2,0.5, 0.5, 1.5,0.2,0.5,0.2,0.1}},
            {"Wizard", new double[]{1.4,0.2,1.5, 0.5, 0,1,1,1,0.2, 0.1}},
        };
        //name; Mults: damage, mana, intl, cc, cd, str, dex, hp
        internal Dictionary<string, UniversalWeapon> weaponCoefficient = new Dictionary<string, UniversalWeapon>()
        {
            {"Palka", new UniversalWeapon("Palka",WeaponRarity.Common,1.05, 1.15, 2, 1.05,0,0,0,0)},
            {"Dagger", new UniversalWeapon("Dagger",WeaponRarity.Rare, 1.1, 0, 0, 1.6,0.7,0,2,0)},
            {"Sword", new UniversalWeapon("Sword",WeaponRarity.Rare, 1.15, 0, 0, 1.35,1.5,2,1,0)},
            {"Axe", new UniversalWeapon("Axe", WeaponRarity.Epic,1.2, 0, 0, 1.2,1.7,2,0,0)},
            {"Hammer", new UniversalWeapon("Hammer",WeaponRarity.Epic, 1.2, 0, 0, 1.1,2.5,2,0,1.15)},
        };
        internal static int[] warriorCurrentStats = new int[] { 30, 15, 10, 25 };
        internal static int[] warriorMaxStats = new int[] { 250, 80, 50, 100 };
        internal static int[] rogueCurrentStats = new int[] { 20, 30, 15, 20 };
        internal static int[] rogueMaxStats = new int[] { 65, 250, 70, 80 };
        internal static int[] wizardCurrentStats = new int[] { 15, 20, 35, 15 };
        internal static int[] wizarMaxStats = new int[] { 45, 80, 250, 70 };

    }
}
