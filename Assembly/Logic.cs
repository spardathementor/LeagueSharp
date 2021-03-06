﻿namespace Flowers_XX
{
    using System.Collections.Generic;
    using Common;
    using LeagueSharp;
    using LeagueSharp.Common;
    using Manager.Menu;
    using Manager.Spells;
    using Manager.Events;

    internal class Logic
    {
        internal static Spell Q;
        internal static Spell W;
        internal static Spell E;
        internal static Spell R;
        internal static SpellSlot Ignite = SpellSlot.Unknown;
        internal static Menu Menu;
        internal static int SkinID;
        internal static int lastCheckTime;
        internal static float lastWardCast;
        internal static Obj_AI_Hero Me;
        internal static Orbwalking.Orbwalker Orbwalker;
        internal static readonly List<ChampionObject> championObject = new List<ChampionObject>();

        internal static void LoadRengar()
        {
            Me = ObjectManager.Player;
            SkinID = ObjectManager.Player.BaseSkinId;

            SpellManager.Init();
            MenuManager.Init();
            EventManager.Init();
        }

        internal static void EnbaleSkin(object obj, OnValueChangeEventArgs Args)
        {
            if (!Args.GetNewValue<bool>())
            {
                ObjectManager.Player.SetSkin(ObjectManager.Player.ChampionName, SkinID);
            }
        }
    }
}
