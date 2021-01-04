using System;
using UnityEngine;
using Multiplayer;
using HumanAPI;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HFFMod
{
    class GravityHand : MonoBehaviour
    {
        private int mode = 0;
        private float leftArmUpStartTime = 0;

        private Transform selectedObject;
        private MeshRenderer selectedObjectRenderer;
        private Rigidbody selectedObjectRigidbody;
        private bool selectedObjectWasKinematic, movingObject;
        private Vector3 offset;
        private float distance;

        private void Start()
        {
            Shell.Print("Gravity Hand Started");
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) => ChangeMode(0);

        private void Update()
        {
            switch (mode)
            {
                case 0:
                    if (Input.GetKeyUp(KeyCode.Alpha1))
                        ChangeMode(1);
                    break;
                case 1:
                    leftArmUpStartTime = Human.all[0].controls.leftExtend == 0 ? 0 : (leftArmUpStartTime == 0 ? Time.time : leftArmUpStartTime);

                    if (Input.GetKeyUp(KeyCode.Alpha1))
                        ChangeMode(1);

                    if (Input.GetMouseButtonUp(1) && selectedObject != null)
                        ChangeMode(2);

                    break;
                case 2:
                    leftArmUpStartTime = Human.all[0].controls.leftExtend == 0 ? 0 : (leftArmUpStartTime == 0 ? Time.time : leftArmUpStartTime);

                    if (Input.GetMouseButton(0))
                    {
                        if (Time.time - leftArmUpStartTime > 0.5f) // para evitar movimientos muy brutos cuando el brazo se esta levantando
                        {
                            movingObject = true;

                            selectedObjectRigidbody.isKinematic = true;
                            if (Input.GetKey(KeyCode.E))
                            {
                                Vector3 v = new Vector3();
                                v -= selectedObject.right * (Input.GetAxis("Mouse X") * 1.5f);
                                v += selectedObject.forward * (Input.GetAxis("Mouse Y") * 1.5f);
                                selectedObject.eulerAngles += v;
                            }
                            else
                            {
                                distance += Input.GetAxis("Mouse ScrollWheel") * 1.5f;
                                selectedObject.position = Human.all[0].ragdoll.partLeftForearm.transform.position - offset + Human.all[0].ragdoll.partLeftForearm.transform.up * distance;
                            }

                            if (Input.GetMouseButtonUp(1))
                                selectedObjectWasKinematic = !selectedObjectWasKinematic;
                        }
                    }
                    else if (Input.GetMouseButtonUp(0))
                        selectedObjectRigidbody.isKinematic = selectedObjectWasKinematic;
                    else if (Input.GetMouseButtonUp(1))
                    {
                        selectedObjectRigidbody.isKinematic = selectedObjectWasKinematic;
                        ChangeMode(0);
                    }
                    else
                        movingObject = false;
                    break;
            }
        }

        private void OnGUI()
        {
            switch (mode)
            {
                case 1:
                    if (Human.all[0].controls.leftExtend == 1f)
                    {
                        if (Physics.Raycast(Human.all[0].ragdoll.partLeftForearm.transform.position + Human.all[0].ragdoll.partLeftForearm.transform.up, Human.all[0].ragdoll.partLeftForearm.transform.up, out RaycastHit hit, 250f))
                        {
                            offset = hit.point;
                            distance = hit.distance;

                            if (selectedObject != null && hit.transform == selectedObject)
                            {
                                DrawBox();
                                return;
                            }

                            Rigidbody rigidbody = hit.transform.GetComponent<Rigidbody>();
                            if (rigidbody != null)
                            {
                                selectedObjectRenderer = null;
                                selectedObject = hit.transform;
                                selectedObjectRigidbody = rigidbody;
                                selectedObjectWasKinematic = rigidbody.isKinematic;
                                DrawBox();
                            }
                        }
                    }
                    break;

                case 2:
                    if (!movingObject) DrawBox();
                    break;
            }
        }

        /// <param name="mode">0=Nothing, 1=Object Selection Mode, 2=Object Selected Mode</param>
        private void ChangeMode(int newMode)
        {
            if (mode == newMode)
            {
                mode = 0;
                return;
            }

            switch (newMode)
            {
                case 1:
                    selectedObject = null;
                    break;
                case 2:
                    offset -= selectedObject.transform.position;
                    break;
            }

            mode = newMode;
        }

        private void DrawBox()
        {
            //top left point of rectangle
            Vector3 boxPosHiLeftWorld;
            //bottom right point of rectangle
            Vector3 boxPosLowRightWorld;

            if (selectedObjectRenderer == null) selectedObjectRenderer = selectedObject.GetComponent<MeshRenderer>();
            if (selectedObjectRenderer != null)
            {
                if (!selectedObjectRenderer.isVisible) return;

                boxPosHiLeftWorld = selectedObject.position + new Vector3(-selectedObjectRenderer.bounds.extents.x, selectedObjectRenderer.bounds.extents.y, selectedObjectRenderer.bounds.extents.z);
                boxPosLowRightWorld = selectedObject.position + new Vector3(selectedObjectRenderer.bounds.extents.x, -selectedObjectRenderer.bounds.extents.y, -selectedObjectRenderer.bounds.extents.z);
            }
            else
            {
                if (selectedObject.name.ToLower().StartsWith("bone"))
                {
                    boxPosHiLeftWorld = selectedObject.position + new Vector3(-0.5f, 0.5f, 0);
                    boxPosLowRightWorld = selectedObject.position + new Vector3(0.5f, -0.5f, 0);
                }
                else
                {
                    boxPosHiLeftWorld = selectedObject.position + new Vector3(-1f, 1f, 0);
                    boxPosLowRightWorld = selectedObject.position + new Vector3(1f, -1f, 0);
                }
            }

            Vector3 boxPosHiLeftCamera = Main.Instance.MainCamera.WorldToScreenPoint(boxPosHiLeftWorld);
            Vector3 boxPosLowRightCamera = Main.Instance.MainCamera.WorldToScreenPoint(boxPosLowRightWorld);

            float width = boxPosHiLeftCamera.x - boxPosLowRightCamera.x;
            float height = boxPosHiLeftCamera.y - boxPosLowRightCamera.y;

            bool negativeWidth = width < 0;
            if (negativeWidth) width = -width;
            if (height < 0) height = -height;

            // Rotation: (couldn't get it to work)
            //GUIUtility.RotateAroundPivot(Quaternion.LookRotation(mainCamera.transform.forward, hit.point).eulerAngles.x, new Vector2(boxPosHiLeftCamera.x + (negativeWidth ? 0 : -width), Screen.height - boxPosHiLeftCamera.y));

            GUI.Box(new Rect(boxPosHiLeftCamera.x + (negativeWidth ? 0 : -width), Screen.height - boxPosHiLeftCamera.y, width, height), selectedObject.name);
        }

        private void OnDestroy() => SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }
}
