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


            transform.position = new Vector3(3.268929f, 3.83699989f, 3.94059467f);
            transform.rotation = Quaternion.Euler(10.3487473f, 200.935837f, 0);
        }
    }
}