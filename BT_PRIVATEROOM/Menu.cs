using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using Console = Colorful.Console;
using System.Runtime.InteropServices;
using System.ComponentModel.Composition;
using System.Threading;
using Fiddler;

namespace BT_PRIVATEROOM
{
    internal class Menu
    {
        public static void MainMenu()
        {

            Console.Title = "BUSINESS TOUR BYPASSER | MADE BY MART | DISCORD.GG/COSMY";
            Console.Clear();
            string texte = "Welcome on Business Tour Bypasser\nThis tool was coded by Mart and you can download it at https://discord.gg/cosmy\n\n\n[1] Launch the game\n[2] Bypass Private Room \n[3] Free Entry Tournament \n[4] Shutdown Cheat \n> ";

            List<char> chars = new List<char>();

            foreach (char c in texte)
            {
                chars.Add(c);
            }
            Console.WriteWithGradient(chars, Color.Yellow, Color.Fuchsia, 14);

            string enter = Console.ReadLine();
            if(enter == "1")
            {
                helper.StartGame();
            }
            else if (enter == "2")
            {
                helper.ClientExecuteScript = true;
                helper.BypassBuyScript();
            }
            else if (enter == "3")
            {
                helper.TournamentGold = true;
                helper.BypassTournament();
            }
            else if (enter == "4")
            {
                FiddlerApplication.Shutdown();
                Console.WriteLine("Done.");
                Thread.Sleep(2300);
                Menu.MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid Choice...");
                Thread.Sleep(1000);
                Menu.MainMenu();
            }
                    
        }

    }
}
