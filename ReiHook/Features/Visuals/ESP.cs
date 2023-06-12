using System.Collections.Generic;
using UnityEngine;
using ReiHook.Utilities;
using System.Linq;
using CTS;

namespace ReiHook.Features.Visuals
{
    public class ESP : MonoBehaviour
    {
        GUIStyle WatermarkStyle = new GUIStyle();
        private static float ReiTimer = 0f;
        private static Camera ReiCamera;
        private static List<CyclistModel> cyclistModel = new List<CyclistModel>();
        private PlayerManager playerManager;
        private PlayerInfoImpact playerInfoImpact;
        private void Start() { WatermarkStyle.normal.textColor = Color.white; }
        private void Update() {
            ReiCamera = Camera.main;
            ReiTimer += Time.deltaTime;
            if (ReiTimer >= 3f) {
                ReiTimer = 0f;
                if (Settings.Player) {
                    cyclistModel = FindObjectsOfType<CyclistModel>().ToList();
                }
            }
        }

        private void OnGUI()
        {
            if (Event.current.type != EventType.Repaint) return;
            if (Settings.Player) {
                if (cyclistModel.Count > 0) {
                    foreach (CyclistModel cyclistModel in cyclistModel) {
                        if (!cyclistModel) continue;
                        playerManager = CTSSingleton<PlayerManager>.Instance;
                        playerInfoImpact = CTSSingleton<PlayerInfoImpact>.Instance;
                        playerInfoImpact = playerManager.GetPlayer() as PlayerInfoImpact;
                        Vector3 Head = cyclistModel.GetCharacterHead().position; Vector3 headPos = ReiCamera.WorldToScreenPoint(Head);
                        Vector3 GetHead = cyclistModel.GetCharacterHead().position + Vector3.up * 0.4f; Vector3 GetHeadPosition = ReiCamera.WorldToScreenPoint(GetHead);
                        float ReiDistance = Vector3.Distance(playerInfoImpact.bIvwNah.transform.position, cyclistModel.transform.position);
                        if (Render.IsOnScreen(headPos)) {
                            Render.DrawString(new Vector2(GetHeadPosition.x, Screen.height - GetHeadPosition.y), "Player", Color.red, true, 12, FontStyle.Normal);
                            Render.DrawString(new Vector2(GetHeadPosition.x, Screen.height - GetHeadPosition.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                        }
                    }
                }
            }
        }
    }
}
