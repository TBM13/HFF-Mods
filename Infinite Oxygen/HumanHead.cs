//File path: Assembly-CSharp.dll/-/HumanHead.cs

using System;
using Multiplayer;
using UnityEngine;

public class HumanHead : WaterSensor, INetBehavior
{
  private float diveTime;

  private void Update()
  {
    int i = 0;
    while (i < this.waterBodies.Count)
    {
      if (this.waterBodies[i].canDrown)
      {
        this.diveTime = 0f;
      }
    }
  } 
}
