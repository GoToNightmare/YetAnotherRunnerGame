using System;
using Cysharp.Threading.Tasks;
using GameFramework.GameEventBus.EventDataTypes;
using Loading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;

namespace Game
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField]
        private AssetReference[] loadableAssetsGameObjects;


        private float LoadingPct01 { get; set; }


        private void Awake()
        {
            GameSettings.SetFramerate();
        }


        private async void Start()
        {
            GameEventBus.AddListener<ED_LoadingGetCurrentPct>(Listener);


            Debug.Log("[GameInit] Start!");
            await LoadAssetsAsync();
        }


        private void OnDestroy()
        {
            GameEventBus.RemoveListener<ED_LoadingGetCurrentPct>(Listener);
        }


        private void Listener(ED_LoadingGetCurrentPct eventData)
        {
            new ED_LoadingProgressChanged()
            {
                ProgressPct01 = LoadingPct01,
            }.TriggerEvent();
        }


        private async UniTask LoadAssetsAsync()
        {
            var toLoad = loadableAssetsGameObjects;
            Assert.IsNotNull(toLoad);

            int current = 0;
            int total = toLoad.Length;
            foreach (var assetReference in toLoad)
            {
                var loadResult = await assetReference.InstantiateAsync();


                var allLoadableComponents = loadResult.GetComponents<ILoadableObject>();
                Assert.IsNotNull(allLoadableComponents);
                Assert.IsTrue(allLoadableComponents.Length > 0);


                foreach (var loadableComponent in allLoadableComponents)
                {
                    await loadableComponent.Load();
                }


                current++;


                // Update cached pct
                var pct01 = (float)current / (float)total;
                LoadingPct01 = Mathf.Clamp01(pct01);


                new ED_LoadingProgressChanged() { ProgressPct01 = LoadingPct01 }.TriggerEvent();
            }


            const float everythingLoaded = 1;
            LoadingPct01 = everythingLoaded;
            new ED_LoadingProgressChanged() { ProgressPct01 = LoadingPct01 }.TriggerEvent();
        }
    }
}