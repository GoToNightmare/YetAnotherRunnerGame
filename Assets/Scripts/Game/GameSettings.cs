using UnityEngine;

namespace Game
{
    public class GameSettings
    {
        private const int DefaultFramerate = 60;


        public static void SetFramerate(int framerate = DefaultFramerate)
        {
            Application.targetFrameRate = framerate;
        }
    }
}