using CTS;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous
{
    public class Missions : MonoBehaviour
    {
        public static void CompleteAllMissions() { CTSSingleton<MissionsManager>.Instance.CompeteAllMissionsCheat(); }
    }
}
