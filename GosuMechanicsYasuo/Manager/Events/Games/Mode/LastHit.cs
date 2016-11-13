﻿namespace GosuMechanicsYasuo.Manager.Events.Games.Mode
{
    using Spells;
    using System.Linq;
    using LeagueSharp.Common;

    internal class LastHit : Logic
    {
        internal static void Init()
        {
            var minions = MinionManager.GetMinions(Me.Position, Q3.Range);

            foreach (
                var minion in
                minions.Where(
                        x =>
                            !x.IsDead &&
                            HealthPrediction.GetHealthPrediction(x, (int) (Me.Distance(x.Position)*1000/2000)) > 0)
                    .OrderByDescending(m => m.Health))
            {
                if (Menu.Item("LastHitQ", true).GetValue<bool>() && Q.IsReady() && !SpellManager.HaveQ3)
                {
                    if (minion.IsValidTarget(Q.Range) && minion.Health < Q.GetDamage(minion))
                    {
                        Q.Cast(minion, true);
                    }
                }

                if (Menu.Item("LastHitQ3", true).GetValue<bool>() && Q.IsReady() && !SpellManager.HaveQ3)
                {
                    if (minion.IsValidTarget(Q3.Range) && minion.Health < Q3.GetDamage(minion))
                    {
                        var qPred = Q3.GetPrediction(minion, true);

                        if (qPred.Hitchance >= HitChance.VeryHigh)
                        {
                            Q3.Cast(qPred.CastPosition, true);
                        }
                    }
                }

                if (Menu.Item("LastHitE", true).GetValue<bool>() && E.IsReady())
                {
                    if (minion.IsValidTarget(E.Range) && minion.Health < E.GetDamage(minion) 
                        && SpellManager.CanCastE(minion))
                    {
                        E.CastOnUnit(minion, true);
                    }
                }
            }
        }
    }
}