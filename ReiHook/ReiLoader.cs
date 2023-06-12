using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace ReiHook
{
    public class ReiLoader
    {
        public static GameObject pLoader;
        public static void ReiAyanami()
        {
            CodeStage.AntiCheat.Detectors.InjectionDetector.Dispose();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.SpeedHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.TimeCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.WallHackDetector.Dispose();
            pLoader = new GameObject();
            pLoader.AddComponent<UI.Menu>();
            pLoader.AddComponent<Features.Visuals.ESP>();
            pLoader.AddComponent<Features.Miscellaneous.UnlimitedBails>();
            pLoader.AddComponent<Features.Bike.Fly>();
            UnityEngine.GameObject.DontDestroyOnLoad(pLoader);
        }

        public static void ReiUnload()
        {
            UnityEngine.Object.Destroy(pLoader);
        }
    }
}
