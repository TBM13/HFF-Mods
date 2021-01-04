using System;
using UnityEngine;
using Multiplayer;
using HumanAPI;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HFFMod
{
    class Main : MonoBehaviour
    {
        private const string version = "DEV";

        public static Main Instance;
        public Camera MainCamera;

        private Vector3 originalGravity;

        private void Start()
        {
            if (Instance != null) // This doesn't always work
            {
                Shell.Print("Old mod instance detected. Destroying...");
                Instance.Destroy();
            }

            Instance = this;
            Shell.Print("HFFMod Started! Version: " + version);

            MainCamera = Camera.main;
            originalGravity = Physics.gravity;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            RegisterCommands();
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            MainCamera = Camera.main;
        }

        #region Commands
        private void RegisterCommands()
        {
            Shell.RegisterCommand("gravityhand", new Action(EnableGravityHand), "gravityhand\r\nEnables the Gravity Hand mod");

            Shell.RegisterCommand("gravity", new Action<string>(GravityCommand), "gravity [gravityValue] [x/y/z]\r\n" +
                "Sets the specified gravity axis to the specified value\r\n\t" +
                "[gravityValue] - Gravity value. If no value is given, the gravity will be restored to its default value\r\n\t" +
                "[x/y/z] - The gravity axis whose value will be changed. If nothing is specified, the Y axis will be changed");

            Shell.RegisterCommand("multiplycatapultsacc", new Action<string>(MultiplyCatapultsAcceleration), "multiplycatapultsacc [value]\r\nMultiplies the acceleration of the catapults in the current level by the given value");
            Shell.RegisterCommand("respawnplayers", new Action<string>(RespawnPlayers), "respawnplayers [x] [y] [z]\r\nRespawns all players in the last checkpoint + an offset (x, y and z)");
            Shell.RegisterCommand("setmaxplayers", new Action<string>(SetMaxPlayers), "setmaxplayers [value]\r\nSets the maximum number of lobby players to the specified value");
            Shell.RegisterCommand("createcube", new Action(CreateCube), "");
            Shell.RegisterCommand("explosion", new Action<string>(Explosion), "explosion [multiplier]\r\nCreates an explosion where the main player is. If the multiplier is 1 or empty, the force will be the same than the force of a firework");
            Shell.RegisterCommand("setcurrent", new Action<string>(SetCurrent), "setcurrent [value]\r\nSets the current of all VoltageToSignal components to the specified value");

            Shell.RegisterCommand("destroymod", new Action(Destroy), "destroymod\r\nUnloads and destroys the mod. Useful to reinject it");
        }

        private void EnableGravityHand() => gameObject.AddComponent<GravityHand>();

        private void GravityCommand(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                Physics.gravity = originalGravity;
                Shell.Print("Gravity restored to its default value");
                return;
            }

            string[] args = arg.Split(' ');
            if (float.TryParse(args[0], out float value))
            {
                Vector3 newGravity = originalGravity;

                if (args.Length == 1)
                    newGravity.y = -value;
                else
                {
                    switch (args[1])
                    {
                        case "x":
                            newGravity.x = -value;
                            break;
                        case "z":
                            newGravity.z = -value;
                            break;
                        default:
                            newGravity.y = -value;
                            break;
                    }
                }

                Physics.gravity = newGravity;
                Shell.Print("Gravity changed to " + arg);
            }
            else
                Debug.LogError("Argument is non-numeric");
        }

        private void MultiplyCatapultsAcceleration(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                Shell.Print("No value was given");
                return;
            }

            if (float.TryParse(arg, out float multiplier))
            {
                int count = 0;
                foreach (CatapultNew catapult in FindObjectsOfType<CatapultNew>())
                {
                    catapult.initialAcceleration *= multiplier;
                    catapult.accelerationAcceleration *= multiplier;
                    count++;
                }

                Shell.Print("Modified " + count + " catapults");
            }
            else
                Debug.LogError("Argument is non-numeric");
        }

        private void RespawnPlayers(string arg)
        {
            Vector3 offset = Vector3.zero;

            if (!string.IsNullOrEmpty(arg))
            {
                string[] args = arg.Split(' ');
                if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
                {
                    if (float.TryParse(args[0], out float x))
                        offset.x = x;
                    else
                    {
                        Debug.LogError("Argument is non-numeric");
                        return;
                    }
                }

                if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                {
                    if (float.TryParse(args[1], out float y))
                        offset.y = y;
                    else
                    {
                        Debug.LogError("Argument is non-numeric");
                        return;
                    }
                }

                if (args.Length > 2 && !string.IsNullOrEmpty(args[2]))
                {
                    if (float.TryParse(args[2], out float z))
                        offset.z = z;
                    else
                    {
                        Debug.LogError("Argument is non-numeric");
                        return;
                    }
                }
            }

            for (int i = 0; i < Human.all.Count; i++)
                Game.instance.Respawn(Human.all[i], offset);
        }

        private void SetMaxPlayers(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                Debug.LogError("No value supplied");
                return;
            }

            if (int.TryParse(arg, out int value))
            {
                PlayerPrefs.SetInt("lobbyMaxPlayers", value);
                Shell.Print($"lobbyMaxPlayers set to {arg}");
            }
            else
                Debug.LogError("Value is non-numeric");
        }

        private void CreateCube()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Rigidbody>();
            cube.AddComponent<NetIdentity>();
            cube.AddComponent<NetBody>();
            //cube.AddComponent<CollisionAudioSensor>();
            cube.transform.position = Human.all[0].transform.position;
        }

        private void Explosion(string arg)
        {
            float multiplier = 1f;
            if (!string.IsNullOrEmpty(arg))
            {
                if (float.TryParse(arg, out float newMultiplier))
                    multiplier = newMultiplier;
                else
                {
                    Debug.LogError("Multiplier is non-numeric");
                    return;
                }
            }

            Collider[] array = Physics.OverlapSphere(Human.all[0].transform.position, 2f * multiplier);
            for (int i = 0; i < array.Length; i++)
            {
                Rigidbody componentInParent = array[i].GetComponentInParent<Rigidbody>();
                if (componentInParent != null && !componentInParent.isKinematic)
                {
                    componentInParent.AddExplosionForce(1500f * multiplier * Mathf.Pow(componentInParent.mass, 0.25f), Human.all[0].transform.position, 8f * multiplier);
                }
            }
        }

        private void SetCurrent(string arg)
        {
            if (string.IsNullOrEmpty(arg))
            {
                Debug.LogError("No value supplied");
                return;
            }

            if (float.TryParse(arg, out float current))
            {
                int i = 0;
                foreach (VoltageToSignal v in FindObjectsOfType<VoltageToSignal>())
                {
                    v.RunCurrent(current);
                    i++;
                }

                Shell.Print($"Modified current of {i} objects");
            }
            else
                Debug.LogError("Value is non-numeric");
        }
        #endregion

        public void Destroy()
        {
            Physics.gravity = originalGravity;
            Debug.LogWarning("HFFMod has been destroyed");
            Destroy(gameObject);
        }
    }
}
