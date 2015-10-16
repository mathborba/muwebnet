using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUwebNET.Web.Framework.Helpers
{
    public class GMarkHelper
    {
        public static string ToTableString(Byte[] g_mark, int size)
        {
            string str = BitConverter.ToString(g_mark).Replace("-", "");
            string result = @"<table style=""width:" + 8 * size + @"px;height:" + 8 * size + @"px;margin:auto;"" border=0 cellpadding=0 cellspacing=0><tr>";
            int count = 0;
            foreach (char c in str)
            {
                count++;
                result += @"<td style=""background-color:" + CharToColor(c) + @";"" width=""" + size + @""" height=""" + size + @"""></td>";
                if (count % 8 == 0)
                {
                    result += @"</tr>";
                    if (count != 64) result += @"<tr>";
                }
            }
            result += "</table>";

            return result;
        }

        private static string CharToColor(char c)
        {
            switch (char.ToLower(c))
            {
                case '0': return " ";
                case '1': return "#000000";
                case '2': return "#8c8a8d";
                case '3': return "#ffffff";
                case '4': return "#fe0000";
                case '5': return "#ff8a00";
                case '6': return "#ffff00";
                case '7': return "#8cff01";
                case '8': return "#00ff00";
                case '9': return "#01ff8d";
                case 'a': return "#00ffff";
                case 'b': return "#008aff";
                case 'c': return "#0000fe";
                case 'd': return "#8c00ff";
                case 'e': return "#ff00fe";
                case 'f': return "#ff008c";
                default:
                    return " ";
            }
        }
    }
}
