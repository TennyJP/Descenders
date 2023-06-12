using CTS;
using System;
using UnityEngine;

namespace ReiHook.Features.Miscellaneous
{
    public class Revive : MonoBehaviour
    {
        public static void RevivePlayer() { CTSSingleton<PlayerInfoImpact>.Instance.Revive(); }
    }
}
