//File path: Assembly-CSharp.dll/-/CheatCodes.cs
//Only code added/modified by the mod is here.

using System;
using I2.Loc;
using Multiplayer;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    private static Vector3 gravityReal;

    private void Start()
    {
        CheatCodes.gravityReal = Physics.gravity;
        Shell.RegisterCommand("gravity", new Action<string>(this.CGravity), "gravity [gravityValue]\r\nSets the gravity to the specified value\r\n\t[gravityValue] - Gravity value, e.g. 0-No Gravity, 3-Low Gravity, -1-Inverted gravity, etc\r\n\tIf no gravityValue is specified, the gravity will be restored to its default value.");
    }

    private void CGravity(string txt)
    {
        if (Physics.gravity != CheatCodes.gravityReal && (string.IsNullOrEmpty(txt) || txt.ToLower() == "false" || txt.ToLower() == "off" || txt.ToLower() == "disable"))
        {
            Physics.gravity = CheatCodes.gravityReal;
            Shell.Print("Gravity mod disabled");
        }
        else
        {
            float newGravity;
            if (Single.TryParse(txt, out newGravity)) //TryParse returns true if txt is a number, and sets newGravity to that number
            {
                Physics.gravity = new Vector3(0.0f, -newGravity, 0.0f);
                Shell.Print("Gravity changed to " + txt);
            }
            else
                Shell.Print("Error: Argument is non-numeric");
        }
    }
}
