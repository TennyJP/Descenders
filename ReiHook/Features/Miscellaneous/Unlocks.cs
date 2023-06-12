using CTS;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous
{
    public class Unlocks : MonoBehaviour
    {
        public static void UnlockAll() {
            DevCommandsGameplay.UnlockAll();
        }
        public static void UnlockAllMaps() {
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Highlands) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Highlands, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Forest) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Forest, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Canyon) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Canyon, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Peaks) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Peaks, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Hell) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Hell, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Desert) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Desert, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Jungle) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Jungle, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Favela) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Favela, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Glaciers) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Glaciers, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Overworld) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Overworld, 3); }
            if (CTSSingleton<GameData>.Instance.GetShortcutProgress(World.Ridges) < 3) { CTSSingleton<GameData>.Instance.SetShortcutProgress(World.Ridges, 3); }
        }
        public static void UnlockAllAchievements() {
            DevCommandsGameplay.UnlockAllAchievements();
        }
        public static void SetTeamDivision() {
            CTSSingleton<GameData>.Instance.SetTeamDivision(cyFLnlM.Descender);
        }
    }
}
