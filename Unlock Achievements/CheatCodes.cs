//File path: Assembly-CSharp.dll/-/CheatCodes.cs
//Only mod code is here, NOT game code.

using System;
using I2.Loc;
using Multiplayer;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{

    private void Start()
    {
        Shell.RegisterCommand("unlockachievements", new Action(UnlockAchievements), "unlockachievements\r\nUnlocks all HFF achievements");
    }

    private void UnlockAchievements()
    {
        foreach (Achievement ach in Enum.GetValues(typeof(Achievement)))
        {
            StatsAndAchievements.UnlockAchievement(ach, false, -1);
        }
    }
}
