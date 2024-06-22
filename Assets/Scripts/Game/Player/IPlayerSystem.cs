using UnityEngine;

namespace Game.Player
{
    public interface IPlayerSystem
    {
        void OnEnable(GameObject playerObj);
        void OnDisable(GameObject playerObj);
    }
}