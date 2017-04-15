using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Yorik
{
    class Program
    {
        private static int Frequency => mainMenu["Freq"].Cast<Slider>().CurrentValue;
        private static bool JustSpam => mainMenu["Spam"].Cast<CheckBox>().CurrentValue;
        private static float LastShout = 0;
        private static Menu mainMenu;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;

        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            mainMenu = MainMenu.AddMenu("Yorik", "Yorik");
            mainMenu.AddGroupLabel("Da best in the hood");
          
            mainMenu.Add("Spam", new CheckBox("Fuck it, just spam YORIK", false));
            mainMenu.AddLabel("Delayed Spam");
            mainMenu.Add("Freq", new Slider("Frequency: {0} seconds:", 30, 1, 200));



            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Game.Time - LastShout > 0 && !JustSpam)
            {
               Chat.Say("/all Yorik Yorik Yorik Yorik Yorik Yorik Yorik Yorik");
                LastShout = Game.Time + Frequency;
            }
            if (JustSpam)
                Chat.Say("/all Yorik Yorik Yorik Yorik Yorik Yorik Yorik Yorik");

        }
    }
}
