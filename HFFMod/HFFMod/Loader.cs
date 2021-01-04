using UnityEngine;

namespace HFFMod
{
    public class Loader
    {
        private static GameObject modParent;

        public static void Init()
        {
            modParent = new GameObject();
            modParent.AddComponent<Main>();
            Object.DontDestroyOnLoad(modParent);
        }

        public static void Unload()
        {
            Object.Destroy(modParent);
        }
    }
}