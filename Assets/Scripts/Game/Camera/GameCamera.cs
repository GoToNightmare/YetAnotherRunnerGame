using Cysharp.Threading.Tasks;
using Loading;
using UnityEngine;

namespace Game.Camera
{
    public class GameCamera : MonoBehaviour, ILoadableObject
    {
        public async UniTask Load()
        {
            await UniTask.NextFrame();

            Debug.Log("[GameCamera] Loaded");
        }
    }
}