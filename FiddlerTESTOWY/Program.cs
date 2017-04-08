using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;
using System.Windows.Media;

namespace FiddlerTESTOWY
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Session> sessions = new List<Session>();
            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            Fiddler.FiddlerApplication.BeforeResponse += FiddlerApplication_BeforeResponse;
            Fiddler.CONFIG.IgnoreServerCertErrors = false;
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);
            Fiddler.FiddlerApplication.Startup(8877, false,true,true);
            //Fiddler.FiddlerApplication.CreateProxyEndpoint(7777, true, "localhost");
            Console.ReadKey();

        }

        private static void FiddlerApplication_BeforeRequest(Session oSession)
        {
            if (oSession.HTTPMethodIs("CONNECT") && oSession["X-PROCESSINFO"].StartsWith("outlook"))
            {
                oSession["x-no-decrypt"] = "boring process";
            }
        }

        private static void FiddlerApplication_BeforeResponse(Session oSession)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(oSession.ToString());
        }
    }
}
