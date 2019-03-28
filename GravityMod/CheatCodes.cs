//File path: Assembly-CSharp.dll/-/CheatCodes.cs
//Only mod code is here, NOT game code.

using System;
using I2.Loc;
using Multiplayer;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
	private static bool gravityCheat;
	private static Vector3 gravityReal;
	
	private void Start()
	{
		CheatCodes.gravityReal = Physics.gravity;
		Shell.RegisterCommand("gravity", new Action<string>(this.CGravity), null);
		Shell.RegisterCommand("mod", new Action(this.modInfo), null);
	}

	private void modInfo()
	{
		Shell.Print("Gravity Mod v1.2");
		Shell.Print("To activate/deactivate the mod, type gravity <value> in console.");
		Shell.Print("Contributors:");
		Shell.Print("TBM 16 and Permamiss");
	}
  
	private void CGravity(string txt)
	{
		if (CheatCodes.gravityCheat && (string.IsNullOrEmpty(txt) || txt.ToLower() == "false" || txt.ToLower() == "off" || txt.ToLower() == "disable"))
		{
			Physics.gravity = CheatCodes.gravityReal;
			CheatCodes.gravityCheat = false;
			Shell.Print("Gravity mod disabled");
			return;
		}
		float newGravity;
		if (Single.TryParse(txt, out newGravity)) //TryParse returns true if txt is a number, and sets newGravity to that number
		{
			Physics.gravity = new Vector3(0.0f, -newGravity, 0.0f);
			CheatCodes.gravityCheat = true;
			Shell.Print("Gravity changed to " + txt);
		}
		else
			Shell.Print("Error: Argument is non-numeric");
	}
}
