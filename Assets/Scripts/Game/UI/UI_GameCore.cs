using Cysharp.Threading.Tasks;
using Loading;
using UnityEngine;

namespace Game.UI
{
    public class UI_GameCore : MonoBehaviour, ILoadableObject
    {
        public async UniTask Load()
        {
            await UniTask.NextFrame();

            Debug.Log("[UI_GameCore] Loaded");
        }
    }
}