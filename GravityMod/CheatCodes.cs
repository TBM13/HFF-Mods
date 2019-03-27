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
		Shell.RegisterCommand("gravity", new Action<string>(this.CGravity), null);
		Shell.RegisterCommand("mod", new Action(this.modInfo), null);
	}

	private void modInfo()
	{
		Shell.Print("Gravity Mod by TBM");
		Shell.Print("Version: 1.1");
		Shell.Print("To activate/deactivate the mod, type gravity <value> on console. Value (optional) can be from 0 to 5.");
	}
  
	private void CGravity(string txt)
	{
		if (CheatCodes.gravityS && string.IsNullOrEmpty(txt))
		{
			Physics.gravity = CheatCodes.gravityV;
			CheatCodes.gravityS = false;
			Shell.Print("Gravity mod disabled");
			return;
		}
		float y = -3f;
		if (txt == "0")
		{
			y = -0.1f;
		}
		else if (txt == "1")
		{
			y = -1f;
		}
		else if (txt == "2")
		{
			y = -2f;
		}
		else if (txt == "4")
		{
			y = -4f;
		}
		else if (txt == "5")
		{
			y = -5f;
		}
		else
		{
			txt = "3";
		}
		Physics.gravity = new Vector3(0f, y, 0f);
		CheatCodes.gravityS = true;
		Shell.Print("Gravity changed to " + txt);
	}

	private static bool gravityS;

	private static Vector3 gravityV = Physics.gravity;
}
