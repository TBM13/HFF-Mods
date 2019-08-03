//The infinite underwater sound bug was making me crazy so i had to make a patch. This seems to have fixed it:
//File path: Assembly-CSharp.dll/-/HumanHead.cs

using System;
using Multiplayer;
using UnityEngine;

public class HumanHead : WaterSensor, INetBehavior
{
    private void Update()
    {
        if (ReplayRecorder.isPlaying || NetGame.isClient)
        {
            return;
        }
        bool flag = false;
        for (int i = 0; i < waterBodies.Count; i++)
        {
            if (waterBodies[i].canDrown)
            {
                flag = true;
                Vector3 vector;
                float num = waterBody.SampleDepth(base.transform.position, out vector);
                if (num > 0f)
                {
                    diveTime += Time.deltaTime;
                    if (num > drownDepth)
                    {
                        diveTime += Time.deltaTime * num;
                    }
                    if (diveTime > drownTime)
                    {
                        Game.instance.Drown(base.GetComponentInParent<Human>());
                        ExitWater(true);
                        underwaterState = 2u;
                    }
                    else
                    {
                        ApplyUnderwaterState(1u);
                        if (diveTime > nextBubble)
                        {
                            PlayBubble(nextBubble / drownTime);
                            while (diveTime > nextBubble)
                            {
                                nextBubble += 0.5f;
                            }
                        }
                        underwaterState = 1u;
                    }
                }
                else
                {
                    underwaterState = 0u;
                    ExitWater(false);
                    StopUnderwaterSound(false); //Added this line
                }
                break;
            }
        }
        if (!flag)
        {
            ExitWater(false);
        }
    }
}