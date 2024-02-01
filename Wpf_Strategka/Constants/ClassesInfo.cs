using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Strategka.Constants
{
    internal class ClassesInfo
    {
        internal Dictionary<string, string> statsInfo = new Dictionary<string, string>(){
            {"Warrior", "Health 2/1vit , 1/str\nMana 1/1 int\np.damage 1/str\narmor 1/dex\nm.damage 0.2/int\nm.defense 05/int\ncrt.chanse 0.2/dex\ncrt.damage 0.1/dex"},
            {"Rogue", "Health 1.5/1vit 0.5/1str\nMana 1.2/int\np.damage 0.5/str+0.5dex\narmor 1.5/dex\nm.damage 0.2/int\nm.defense 0.5/int\ncrt.chanse 0.2/dex\ncrt.damage 0.1/dex\n"},
            {"Wizard", "Health 1.4/Vit 0.2/str\nMana 1.5/int\np.damage 0.5/str\narmor 1/dex\nm.damage 1/int\nm.defense 1/int\ncrt.chanse O.2/dex\ncrt.damage 0.1/dex\n"},
        };
        internal Dictionary<string, string> heroInfo = new Dictionary<string, string>(){
            {"Warrior", $"Strength {warriorCurrentStats[0]}/250\nDexterity {warriorCurrentStats[1]}/80\nIntelligence {warriorCurrentStats[2]}/50\nVitality {warriorCurrentStats[3]}/100\n"},
            {"Rogue", $"Strength {rogueCurrentStats[0]}/65\nDexterity {rogueCurrentStats[1]}/250\nIntelligence {rogueCurrentStats[2]}/70\nVitality {rogueCurrentStats[3]}/80\n"},
            {"Wizard", $"Strength {wizardCurrentStats[0]}/250\nDexterity {wizardCurrentStats[1]}/80\nIntelligence {wizardCurrentStats[2]}/250\nVitality {wizardCurrentStats[3]}/70\n"},
        };
        internal static int[] warriorCurrentStats = new int[] { 30, 15, 10, 25 };
        internal static int[] rogueCurrentStats = new int[] { 20, 30, 15, 20 };
        internal static int[] wizardCurrentStats = new int[] { 15, 20, 35, 15 };
    }
}
