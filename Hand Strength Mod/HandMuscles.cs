//File path: Assembly-CSharp.dll/-/HandMuscles.cs
//Only mod code is here, NOT game code.

using System;
using HumanAPI;
using UnityEngine;

//Values needs some adjustments, and the mod itself it's just a directly modification of some hand muscles variables.
//I will try to make a system to modify those variables from CheatCodes.cs so i can allow to enable and disable the mod in-game. Nothing is promised.

[Serializable]
public class HandMuscles
{
  public float maxHorizontalForce = 750f;
  
	public float maxVertialForce = 1500f;
  
  public float grabMaxHorizontalForce = 750f;

	public float grabMaxVertialForce = 1500f;
  
  public float maxPushForce = 600f;
  
  public float maxForce = 900f;

	public float grabMaxForce = 1350f;
  
  public float maxStopForce = 450f;

	public float grabMaxStopForce = 1500f;
}
