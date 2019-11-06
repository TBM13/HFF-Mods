//File path: Assembly-CSharp.dll/-/Game.cs
//Only code added/modified by the mod is here.

public class Game : MonoBehaviour, IGame, IDependency
{
    public void Initialize()
    {
        foreach (string level in levels)
        {
            MonoBehaviour.print(level);
        }
    }
}
