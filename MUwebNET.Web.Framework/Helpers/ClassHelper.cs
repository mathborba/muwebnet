using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUwebNET.Web.Framework.Helpers
{
    public class ClassHelper
    {
        static public string ToString(int code)
        {
            string var =
                code == 0 ? "Dark Wizard"
                : code == 1 ? "Soul Master"
                : code == 3 ? "Grand Master"
                : code == 16 ? "Dark Knight"
                : code == 17 ? "Blade Knight"
                : code == 19 ? "Blade Master"
                : code == 32 ? "Elf"
                : code == 33 ? "Muse Elf"
                : code == 35 ? "High Elf"
                : code == 48 ? "Magic Gladiator"
                : code == 50 ? "Duel Master"
                : code == 64 ? "Dark Lord"
                : code == 66 ? "Lord Emperor"
                : code == 80 ? "Summoner"
                : code == 81 ? "Bloody Summoner"
                : code == 83 ? "Dimension Master"
                : code == 96 ? "Rage Fighter"
                : code == 98 ? "Fist Master"
                : "Desconhecido";
            return var;
        }

        static public string ToShortString(int code)
        {
            string var =
                code == 0 ? "DW"
                : code == 1 ? "SM"
                : code == 3 ? "GrM"
                : code == 16 ? "DK"
                : code == 17 ? "BK"
                : code == 19 ? "BM"
                : code == 32 ? "Elf"
                : code == 33 ? "ME"
                : code == 35 ? "HE"
                : code == 48 ? "MG"
                : code == 50 ? "DM"
                : code == 64 ? "DL"
                : code == 66 ? "LE"
                : code == 80 ? "Sum"
                : code == 81 ? "BS"
                : code == 83 ? "DiM"
                : code == 96 ? "RF"
                : code == 98 ? "FM"
                : "Desconhecido";
            return var;
        }
    }
}
