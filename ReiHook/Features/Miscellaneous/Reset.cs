using Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiHook.Features.Miscellaneous
{
    public class Reset : MonoBehaviour
    {
        public static void ResetEverything() { DevCommandsGameplay.DeleteAll(); }
    }
}
