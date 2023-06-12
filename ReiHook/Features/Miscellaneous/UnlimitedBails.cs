using CTS;
using ReiHook.Utilities;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous
{
    public class UnlimitedBails : MonoBehaviour
    {
        private void Update()
        {
            if (Settings.UnlimitedBails) { CTSSingleton<PlayerInfoImpact>.Instance.Heal(99); }
        }
    }
}
