using Cysharp.Threading.Tasks;
using Game.Core.GameEventBusVariants.EventDataTypes;
using GameFramework.GameEventBus;
using Loading;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Core
{
    public class GameLevelGenerator : MonoBehaviour, ILoadableObject
    {
        [SerializeField]
        private AssetReference map;


        [SerializeField]
        private AssetReference player;


        private GameObject MapReference { get; set; }
        private GameObject PlayerReference { get; set; }


        public async UniTask Load()
        {
            await UniTask.NextFrame();

            Debug.Log("[GameLevelGenerator] Loaded");
        }


        private async UniTask GenerateLevel()
        {
        }


        private void Start()
        {
            GameEventBus.AddListener<ED_PrepareGameMap>(PrepareGameMapRequest);
        }


        private void OnDestroy()
        {
            GameEventBus.RemoveListener<ED_PrepareGameMap>(PrepareGameMapRequest);
        }


        private void PrepareGameMapRequest(ED_PrepareGameMap eventData)
        {
            PreparingGameMap().Forget();
        }


        private async UniTask PreparingGameMap()
        {
            Debug.Log("Generating game map started");


            MapReference = await Addressables.InstantiateAsync(map);
            if (MapReference.TryGetComponent(out IGameplayObject gameplayObjectMap))
            {
                await gameplayObjectMap.Init();
                await gameplayObjectMap.CustomEnable();
            }


            PlayerReference = await Addressables.InstantiateAsync(player);
            if (PlayerReference.TryGetComponent(out IGameplayObject gameplayObjectPlayer))
            {
                await gameplayObjectPlayer.Init();
                await gameplayObjectPlayer.CustomEnable();
            }


            // Addressables.ReleaseInstance(mapObj);


            Debug.Log("Generating game map finished");


            new ED_GameMapReady().TriggerEvent();
        }
    }
}