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
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_AZTEC_CLOCWORK, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_AZTEC_INDIANA, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_AZTEC_OVERLOOK, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_BREAK_BARE_HANDS, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_BREAK_SURPRISE, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_BREAK_WINDOW_SHORTCUT, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CARRY_1000M, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CARRY_BIG_STACK, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CARRY_JAM_DOOR, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CLIMB_100M, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CLIMB_GEMS, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CLIMB_ROPE, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_CLIMB_SPEAKERS, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_DRIVE_1000M, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_DROWN_10, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_DUMPSTER_50M, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_FALL_1, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_FALL_1000, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_HALLOWEEN_FRY_ME_TO_THE_MOON, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_HALLOWEEN_LIKE_CLOCKWORK, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_HALLOWEEN_PLANKS_NO_THANKS, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_INTRO_JUMP_GAP, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_INTRO_STATUE_HEAD, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_JUMP_1000, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_AZTEC, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_BREAK, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_CARRY, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_CLIMB, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_HALLOWEEN, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_INTRO, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_POWER, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_PUSH, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_RIVER_FEET, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_RIVER_HEAD, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_LVL_SIEGE, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_POWER_3VOLTS, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_POWER_COAL_DELIVER, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_POWER_SHORT_CIRCUIT, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_POWER_STATUE_BATTERY, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_PUSH_BENCH_ALIGN, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_PUSH_CLEAN_DEBRIS, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_SHIP_1000M, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_SIEGE_ASSASIN, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_SIEGE_BELL, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_SIEGE_HUMAN_CANNON, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_SIEGE_ZIPLINE, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_SINGLE_RUN, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_TRAVEL_100KM, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_TRAVEL_10KM, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_TRAVEL_1KM, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_WATER_ALMOST_DROWN, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_WATER_LIGHTHOUSE, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_WATER_REVERSE_GEAR, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_WATER_ROW_BOAT, false, -1);
        StatsAndAchievements.UnlockAchievement(Achievement.ACH_WATER_SURF, false, -1);
    }
}
