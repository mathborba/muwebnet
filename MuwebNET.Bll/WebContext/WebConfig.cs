using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.WebContext
{
    public static class WebConfig
    {
        public static string GetAvaibleServerConnectState()
        {
            try
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect("msnet.sytes.net", 44405);

                if (sock.Connected)
                {
                    return "Online";
                }
                else
                {
                    return "Offline";
                }
            }
            catch(Exception ex)
            {
                return "Offline";
            }
        }
    }
}
