//File path: Assembly-CSharp.dll/-/LegMuscles.cs
//Only code added/modified by the mod is here.

using System;
using UnityEngine;

[Serializable]
public partial class LegMuscles
{
    private void JumpAnimation(Vector3 torsoFeedback)
    {
        upImpulse = ((((Mathf.Sqrt(2f * 0.75f / Physics.gravity.magnitude) + ((Mathf.Pow(Mathf.Clamp(this.human.groundManager.groudSpeed.y, 0f, 100f), 1.2f))) / Physics.gravity.magnitude)) * this.human.weight) - momentum.y) * CheatCodes.jumpImpulse;
    }
}