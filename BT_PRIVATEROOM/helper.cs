using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Fiddler;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Drawing;

namespace BT_PRIVATEROOM
{
    internal class helper
    {

        public static bool ClientExecuteScript = false;
        public static int nb_request_successed = 0;

        private static void ScrapDataRequest(Session oSession)
        {
            oSession.bBufferResponse = true;

        }

        private static void ScrapDataResponse(Session oSession)
        {
            if (oSession.fullUrl.Equals("https://7eaa.playfabapi.com/Client/GetUserInventory?sdk=UnitySDK-2.153.221024"))
            {

                oSession.utilDecodeResponse();
                File.WriteAllText("player_data.json", oSession.GetResponseBodyAsString());
                Process[] game = Process.GetProcessesByName("BusinessTour");
                game[0].Kill();
                FiddlerApplication.Shutdown();
                Console.WriteLine("Data Scraped... Back to main menu");
                Thread.Sleep(2500);
                Menu.MainMenu();





            }
      
        }


        private static void GameRequest(Session oSession)
        {
            oSession.bBufferResponse = true;

        }

        private static void GameResponse(Session oSession)
        {
        
            if (ClientExecuteScript == true)
            {
       

                if (oSession.fullUrl.Equals("https://7eaa.playfabapi.com/Client/GetFriendsList?sdk=UnitySDK-2.153.221024"))
                {

                    Console.WriteLine("Success ! In-App Purchase Bypassed. You are now in Private Table");
                    ClientExecuteScript = false;
                    Thread.Sleep(4000);
                    FiddlerApplication.Shutdown();
                    Menu.MainMenu();


                }
                if (oSession.fullUrl.Equals("https://7eaa.playfabapi.com/Client/GetUserReadOnlyData?sdk=UnitySDK-2.153.221024"))
                {

                    oSession.utilDecodeResponse();
                    WebClient wc = new WebClient();
                    oSession.utilSetResponseBody(wc.DownloadString("https://pastebin.com/raw/WsW3WCt8"));





                }
                if (oSession.fullUrl.Equals("https://7eaa.playfabapi.com/Client/ExecuteCloudScript?sdk=UnitySDK-2.153.221024"))
                {

                    oSession.utilDecodeResponse();
                    oSession.utilSetResponseBody(File.ReadAllText("bypass_request.json"));
                    Console.WriteLine("Trying to bypass...");





                }
            }
            else
            {
                if (oSession.fullUrl.Equals("https://7eaa.playfabapi.com/Client/GetUserReadOnlyData?sdk=UnitySDK-2.153.221024"))
                {

                    oSession.utilDecodeResponse();
                    WebClient wc = new WebClient();
                    oSession.utilSetResponseBody(wc.DownloadString("https://pastebin.com/raw/WsW3WCt8"));





                }
            }
        }
        public static void ScrapData()
        {
            CertMaker.createRootCert();
            CertMaker.trustRootCert();
            FiddlerCoreStartupSettings startupSettings = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(50244).RegisterAsSystemProxy().DecryptSSL().Build();
            Console.Clear();
            FiddlerApplication.Startup(startupSettings);

            FiddlerApplication.BeforeRequest += ScrapDataRequest;
            FiddlerApplication.BeforeResponse += ScrapDataResponse;
            Console.WriteLine("Proxy Enabled... ");
            Console.WriteLine("Waiting for requests...");
            Process.Start("steam://rungameid/397900");
            Process[] game_id = Process.GetProcessesByName("BusinessTour");

            Console.WriteLine("Please wait...");
            Console.Read();

        }


        public static void BypassBuyScript()
        {
            Console.Clear();
            Console.WriteLine("Bypassing In-App Purchase...");
            Console.WriteLine("Please click on the Subscribe button");

            Console.ReadLine();

        }

        public static void StartGame()
        {
            CertMaker.createRootCert();
            CertMaker.trustRootCert();
            FiddlerCoreStartupSettings startupSettings = new FiddlerCoreStartupSettingsBuilder().ListenOnPort(50244).RegisterAsSystemProxy().DecryptSSL().Build();
            Console.Clear();
            FiddlerApplication.Startup(startupSettings);

            FiddlerApplication.BeforeRequest += GameRequest;
            FiddlerApplication.BeforeResponse += GameResponse;
            Console.WriteLine("Proxy Enabled... ");
            Process.Start("steam://rungameid/397900");
            Process[] game_id = Process.GetProcessesByName("BusinessTour");

            Console.WriteLine("Enjoy!");
            Thread.Sleep(4000);
  

            
            Menu.MainMenu();
    

        }


      



    }
}
