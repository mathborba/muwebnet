using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUwebNET.Web.Framework.Helpers
{
    public class MapHelper
    {
        static public string ToString(int code)
        {
            string var = code == 0 ? "Lorencia"
                : code == 1 ? "Dungeon"
                : code == 2 ? "Devias"
                : code == 3 ? "Noria"
                : code == 4 ? "LostTower"
                : code == 5 ? "Exile"
                : code == 6 ? "Arena"
                : code == 7 ? "Atlans"
                : code == 8 ? "Tarkan"
                : (code == 9 || code == 32) ? "DS"
                : code == 10 ? "Icarus"
                : ((code >= 11 && code <= 17) || (code == 52)) ? "BC"
                : ((code >= 18 && code <= 23) || (code == 53)) ? "CC"
                : ((code >= 24 && code <= 29) || (code == 36)) ? "Kalima"
                : code == 30 ? "Valley of Loren"
                : code == 31 ? "Land of Trials"
                : code == 33 ? "Aida"
                : code == 34 ? "Crywolf"
                : code == 37 ? "Kanturu"
                : code == 38 ? "Kanturu 2"
                : code == 39 ? "Kanturu 3"
                : code == 40 ? "Silent Map"
                : code == 41 ? "Barracks"
                : code == 42 ? "Refuge"
                : (code >= 45 && code <= 50) ? "Illusion Temple"
                : code == 51 ? "Elveland"
                : code == 56 ? "Swamp of Calmness"
                : (code == 57 || code == 58) ? "LaCleon"
                : code == 62 ? "Santa's Village"
                : (code == 63 || code == 64) ? "Vulcanus"
                : (code >= 65 && code <= 68) ? "Doppleganger"
                : (code >= 69 && code <= 72) ? "Imperial Guardian"
                : (code == 80 || code == 81) ? "Kalrutan"
                : "Desconhecido";
            return var;
        }
    }
}
