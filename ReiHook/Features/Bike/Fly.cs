using CTS;
using ReiHook.UI;
using ReiHook.Utilities;
using System;
using System.Net;
using UnityEngine;

namespace ReiHook.Features.Bike
{
    public class Fly : MonoBehaviour
    {
        private PlayerManager playerManager;
        private PlayerInfoImpact playerInfoImpact;
        public static Camera ReiCamera;
        public float slowMoveFactor = 0.25f;
        public float fastMoveFactor = 3;
        private float rotationX = 0.0f;
        private float rotationY = 0.0f;
        private bool _fly = false;
        private void Start() { ReiCamera = Camera.main; }
        private void Update()
        {
            if (Settings.Fly) {
                if (Input.GetKeyDown(KeyCode.F5)) { _fly = !_fly;
                playerManager = CTSSingleton<PlayerManager>.Instance;
                playerInfoImpact = CTSSingleton<PlayerInfoImpact>.Instance;
                playerInfoImpact = playerManager.GetPlayer() as PlayerInfoImpact; } }
            if (_fly)
            {
                if (Menu.bGUI) return;
                if (Event.current.type != EventType.Repaint) return;
                playerInfoImpact.bIvwNah.bYxcVhv = false;
                playerInfoImpact.bIvwNah.Reset(true);
                playerInfoImpact.bIvwNah.transform.rotation = Camera.main.transform.rotation;
                rotationX += Input.GetAxis("Mouse X") * Settings.CameraSensitivity * Time.deltaTime;
                rotationY += Input.GetAxis("Mouse Y") * Settings.CameraSensitivity * Time.deltaTime;
                rotationY = Mathf.Clamp(rotationY, -90, 90);

                playerInfoImpact.bIvwNah.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
                playerInfoImpact.bIvwNah.transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.forward * (Settings.MoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                    playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.right * (Settings.MoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
                }
                else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.forward * (Settings.MoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                    playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.right * (Settings.MoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
                }
                else
                {
                    playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.forward * Settings.MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
                    playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.right * Settings.MoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
                }


                if (Input.GetKey(KeyCode.Q)) { playerInfoImpact.bIvwNah.transform.position += playerInfoImpact.bIvwNah.transform.up * Settings.ClimbSpeed * Time.deltaTime; }
                if (Input.GetKey(KeyCode.E)) { playerInfoImpact.bIvwNah.transform.position -= playerInfoImpact.bIvwNah.transform.up * Settings.ClimbSpeed * Time.deltaTime; }
            }
            else { Cursor.lockState = CursorLockMode.None; playerInfoImpact.bIvwNah.bYxcVhv = true; }
        }
    }
}
