using UnityEngine;
using ReiHook.Utilities;

namespace ReiHook.UI
{
    public class Menu : MonoBehaviour
    {
        private Rect MainWindow;
        private Rect PlayerWindow;
        private Rect VisualWindow;
        private Rect MiscellaneousWindow;
        private Rect ModifierWindow;

        Vector2 ScrollPosition;
        GUIStyle WatermarkStyle = new GUIStyle();
        GUIStyle LabelStyle = new GUIStyle();

        public static bool bGUI = false;
        private bool bPlayerWindow = false;
        private bool bVisualWindow = false;
        private bool bMiscellaneousWindow = false;
        private bool bModifierWindow = false;
        private void Start()
        {
            MainWindow = new Rect(20f, 60f, 250f, 120f);
            WatermarkStyle.normal.textColor = Color.yellow; LabelStyle.normal.textColor = Color.white;
        }

        private void Update()
        {
            ToggleMenu();
            if(Input.GetKeyDown(KeyCode.Delete)) { ReiLoader.ReiUnload(); }
        }

        private void ToggleMenu()
        {
            if (Input.GetKeyDown(KeyCode.F4))
            {
                bGUI = !bGUI;
                if (bGUI)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(20, 20, 200, 60), "UnKnoWnCheaTs.me | Tenny", WatermarkStyle); GUI.Label(new Rect(20, 40, 200, 60), "ReiHook for Descenders v1.2", WatermarkStyle);
            if (!bGUI) return;
            GUI.backgroundColor = Color.black;
            MainWindow = GUILayout.Window(0, MainWindow, new GUI.WindowFunction(UI), "Menu", new GUILayoutOption[0]);
            if (bPlayerWindow) { PlayerWindow = GUILayout.Window(1, PlayerWindow, new GUI.WindowFunction(UI), "Player", new GUILayoutOption[0]); }
            if (bVisualWindow) { VisualWindow = GUILayout.Window(2, VisualWindow, new GUI.WindowFunction(UI), "Visual", new GUILayoutOption[0]); }
            if (bMiscellaneousWindow) { MiscellaneousWindow = GUILayout.Window(3, MiscellaneousWindow, new GUI.WindowFunction(UI), "Miscellaneous", new GUILayoutOption[0]); }
            if (bModifierWindow) { ModifierWindow = GUILayout.Window(4, ModifierWindow, new GUI.WindowFunction(UI), "Modifiers", new GUILayoutOption[0]); }
        }

        private void UI(int pID)
        {
            GUI.backgroundColor = Color.black; GUI.contentColor = Color.white;
            switch (pID)
            {
                case 0:
                    GUILayout.Label("Press F4 for Menu", LabelStyle, new GUILayoutOption[0]);
                    GUILayout.Label("Delete to Unhook the Cheat", LabelStyle, new GUILayoutOption[0]);
                    if (GUILayout.Button("Player", new GUILayoutOption[0])) { bPlayerWindow = !bPlayerWindow; }
                    if (GUILayout.Button("Visual", new GUILayoutOption[0])) { bVisualWindow = !bVisualWindow; }
                    if (GUILayout.Button("Miscellaneous", new GUILayoutOption[0])) { bMiscellaneousWindow = !bMiscellaneousWindow; }
                    break;
                case 1:
                    Settings.Fly = GUILayout.Toggle(Settings.Fly, "Fly [F5]", new GUILayoutOption[0]);
                    GUILayout.Label("Camera Sensitivity: " + Mathf.Round(Settings.CameraSensitivity), LabelStyle, new GUILayoutOption[0]);
                    Settings.CameraSensitivity = Mathf.Round(GUILayout.HorizontalSlider(Settings.CameraSensitivity, 1f, 400f, new GUILayoutOption[0]) * 400f) / 400f;
                    GUILayout.Label("Move Speed: " + Mathf.Round(Settings.MoveSpeed), LabelStyle, new GUILayoutOption[0]);
                    Settings.MoveSpeed = Mathf.Round(GUILayout.HorizontalSlider(Settings.MoveSpeed, 1f, 100f, new GUILayoutOption[0]) * 100f) / 100f;
                    GUILayout.Label("Climb Speed: " + Mathf.Round(Settings.ClimbSpeed), LabelStyle, new GUILayoutOption[0]);
                    Settings.ClimbSpeed = Mathf.Round(GUILayout.HorizontalSlider(Settings.ClimbSpeed, 1f, 25f, new GUILayoutOption[0]) * 25f) / 25f;
                    break;
                case 2:
                    Settings.Player = GUILayout.Toggle(Settings.Player, "Player", new GUILayoutOption[0]);
                    break;
                case 3:
                    if (GUILayout.Button("Unlock All", new GUILayoutOption[0])) { Features.Miscellaneous.Unlocks.UnlockAll(); }
                    if (GUILayout.Button("Unlock All Maps", new GUILayoutOption[0])) { Features.Miscellaneous.Unlocks.UnlockAllMaps(); }
                    if (GUILayout.Button("Unlock All Achievements", new GUILayoutOption[0])) { Features.Miscellaneous.Unlocks.UnlockAllAchievements(); }
                    if (GUILayout.Button("Max Team Division", new GUILayoutOption[0])) { Features.Miscellaneous.Unlocks.SetTeamDivision(); }
                    GUILayout.Space(10);
                    GUILayout.Label("In Game:", LabelStyle, new GUILayoutOption[0]);
                    Settings.UnlimitedBails = GUILayout.Toggle(Settings.UnlimitedBails, "Unlimited Bails", new GUILayoutOption[0]);
                    if (GUILayout.Button("Modifiers", new GUILayoutOption[0])) { bModifierWindow = !bModifierWindow; }
                    if (GUILayout.Button("Add Score: " + Settings.iAddScore, new GUILayoutOption[0])) { Features.Miscellaneous.Score.AddScore(); }
                    Settings.iAddScore = (int)GUILayout.HorizontalSlider(Settings.iAddScore, 1, 1000000, new GUILayoutOption[0]);
                    if (GUILayout.Button("Add Random Score", new GUILayoutOption[0])) { Features.Miscellaneous.Score.AddRandomScore(); }
                    if (GUILayout.Button("Jump to Finish Line", new GUILayoutOption[0])) { Features.Miscellaneous.Finish.JumpToFinishLine(); }
                    GUILayout.Space(10);
                    GUILayout.Label("Reset:", LabelStyle, new GUILayoutOption[0]);
                    if (GUILayout.Button("Reset Player Stats", new GUILayoutOption[0])) { Features.Miscellaneous.Reset.ResetEverything(); ; }
                    break;
                case 4:
                    ScrollPosition = GUILayout.BeginScrollView(ScrollPosition, GUILayout.Width(250), GUILayout.Height(500));
                    for (var i = 0; i < ModifierNames.Modifiers.Count; i++)
                    {
                        if (GUILayout.Button(ModifierNames.Modifiers[i], new GUILayoutOption[0])) { DevCommandsGameplay.AddModifier(ModifierNames.Modifiers[i]); }
                    }
                    GUILayout.EndScrollView();
                    break;
                default:
                    break;
            }
            GUI.DragWindow();
        }
    }
}
