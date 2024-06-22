using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Core;
using UnityEngine;

namespace Game.Player
{
    public class Player : MonoBehaviour, IGameplayObject
    {
        private readonly List<IPlayerSystem> playerSystems = new List<IPlayerSystem>()
        {
            { new PlayerCamera() },
        };


        public async UniTask Init()
        {
        }


        public async UniTask CustomEnable()
        {
            var playerGo = gameObject;
            foreach (var ps in playerSystems)
            {
                ps.OnEnable(playerGo);
            }
        }


        public async UniTask CustomDisable()
        {
            var playerGo = gameObject;
            foreach (var ps in playerSystems)
            {
                ps.OnDisable(playerGo);
            }
        }
    }
}