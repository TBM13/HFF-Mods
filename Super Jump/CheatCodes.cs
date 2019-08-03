//File path: Assembly-CSharp.dll/-/CheatCodes.cs
//Only code added/modified by the mod is here.

using System;
using I2.Loc;
using Multiplayer;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
  public static float jumpImpulse = 1f;
	
  private void Start()
  {
    Shell.RegisterCommand("jumpimp", new Action<string>(modifyJumpImpulse), "jumpimp <value>\r\nModify jump impulse value\r\n\t<value> - impulse value, e.g. 0-No jump, 0-No jump, 0.5-Small jump, 5-Super Jump");
    Shell.RegisterCommand("jumpimpulse", new Action<string>(modifyJumpImpulse), "jumpimpulse <value>\r\nModify jump impulse value\r\n\t<value> - impulse value, e.g. 0-No jump, 0.5-Small jump, 5-Super Jump");
    Shell.RegisterCommand("jumpmod", new Action<string>(modifyJumpImpulse), "jumpmod <value>\r\nModify jump impulse value\r\n\t<value> - impulse value, e.g. 0-No jump, 0.5-Small jump, 5-Super Jump");
  }
  
  private void modifyJumpImpulse(string txt)
  {
    if (Single.TryParse(txt, out jumpImpulse))
      Shell.Print("Jump impulse changed to " + txt);
    else
     Shell.Print("Error: Argument is non-numeric");
  }
}