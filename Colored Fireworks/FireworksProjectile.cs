//File path: Assembly-CSharp.dll/-/FireworksProjectile.cs
//Only code added/modified by the mod is here.

public class FireworksProjectile : MonoBehaviour, INetBehavior
{
	private Color customColor = Color.clear;
	
	private void Apply(FireworksProjectile.FireworkState newState, float newPhase, bool manageLifetime = false)
	{
		if (this.customColor == Color.clear)
		{
			int colorResult = new System.Random().Next(0, 7);
			if (colorResult == 0)
				this.customColor = Color.yellow;
			else if (colorResult == 1)
				this.customColor = Color.red;
			else if (colorResult == 2)
				this.customColor = Color.green;
			else if (colorResult == 3)
				this.customColor = Color.blue;
			else if (colorResult == 4)
				this.customColor = Color.white;
			else if (colorResult == 5)
				this.customColor = Color.magenta;
			else
				this.customColor = Color.cyan;
		}
		
		this.light.color = this.customColor;
		this.flyParticles.startColor = this.customColor;
		this.explodeParticles.startColor = this.customColor;
	}
}