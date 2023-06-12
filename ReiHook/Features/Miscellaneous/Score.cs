using ReiHook.Utilities;
using System;
namespace ReiHook.Features.Miscellaneous
{
    public class Score
    {
        public static void AddScore() { DevCommandsGameplay.AddScore(Settings.iAddScore); }
        public static void AddRandomScore() { DevCommandsGameplay.AddScore(new Random().Next(1, 100000)); }
    }
}
