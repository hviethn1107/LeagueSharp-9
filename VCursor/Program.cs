﻿using System;
using LeagueSharp.Common;

namespace VCursor
{
    internal class Program
    {
        public static Menu Menu;
        public static bool FollowMovement => Menu.Item("Movement").IsActive();

        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            Menu = new Menu("VCursor", "VCursor", true);
            Menu.AddItem(new MenuItem("Movement", "Follow Cursor Movement").SetValue(true));
            Menu.AddItem(new MenuItem("Icon", "Change Icon [BROKEN IN L#]").SetValue(true));
            Menu.AddToMainMenu();

            FakeClicks.Initialize(Menu);

            VirtualCursor.Initialize();
            VirtualCursor.Draw();
        }
    }
}