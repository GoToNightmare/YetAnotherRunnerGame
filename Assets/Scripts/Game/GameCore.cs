using Cysharp.Threading.Tasks;
using Loading;
using UnityEngine;

namespace Game
{
    public class GameCore : MonoBehaviour, ILoadableObject
    {
        public async UniTask Load()
        {
            await UniTask.NextFrame();

            Debug.Log("[GameCore] Loaded");
        }
    }
}