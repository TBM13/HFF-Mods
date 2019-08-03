//File path: Assembly-CSharp.dll/-/LegMuscles.cs
//Only code added/modified by the mod is here.

using System;
using UnityEngine;

[Serializable]
public partial class LegMuscles
{
  private void JumpAnimation(Vector3 torsoFeedback)
  {
    upImpulse = ((Mathf.Sqrt(4f / Physics.gravity.magnitude) * human.weight) - momentum.y) * 5f;
  }
}
