using System;
using Game.Core.GameEventBusVariants.EventDataTypes;
using GameFramework.GameEventBus;
using GameFramework.GameReactiveProperty;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UI_Loading : MonoBehaviour
    {
        [SerializeField]
        private Image loadingBar;


        [SerializeField]
        private GameObject loadingParent;


        private GameReactivePropertyOldAndNew<float> progressBarPct;


        private void Start()
        {
            GameEventBus.AddListener<ED_LoadingProgressChanged>(ProgressChanged);
            GameEventBus.AddListener<ED_LevelLoadingStart>(LevelLoadingStart);
            GameEventBus.AddListener<ED_LevelLoadingEnd>(LevelLoadingEnd);
        }


        private void OnDestroy()
        {
            GameEventBus.RemoveListener<ED_LoadingProgressChanged>(ProgressChanged);
            GameEventBus.AddListener<ED_LevelLoadingStart>(LevelLoadingStart);
            GameEventBus.AddListener<ED_LevelLoadingEnd>(LevelLoadingEnd);
        }


        private void LevelLoadingStart(ED_LevelLoadingStart eventData)
        {
            ChangeProgressBar(0);
            ChangeState(true);
        }


        private void LevelLoadingEnd(ED_LevelLoadingEnd eventData)
        {
            ChangeProgressBar(1);
            ChangeState(false);
        }


        private void OnEnable()
        {
            new ED_LoadingGetCurrentPct().TriggerEvent();
        }


        private void ProgressChanged(ED_LoadingProgressChanged eventData)
        {
            var pct = eventData.ProgressPct01;
            pct = Mathf.Clamp01(pct);

            ChangeProgressBar(pct);


            if (eventData.Finished)
            {
                ChangeState(false);
            }
        }


        private void ChangeState(bool loadingUiActive)
        {
            loadingParent.SetActive(loadingUiActive);
        }


        private void ChangeProgressBar(float pct)
        {
            if (progressBarPct == null) // if null then create new with initial value
            {
                progressBarPct = new GameReactivePropertyOldAndNew<float>()
                {
                    Value = -1,
                    OnChange = ProgressBarPctOnChange
                };
            }

            progressBarPct.Value = pct; // would trigger `OnChange` delegate if value changed
        }


        private void ProgressBarPctOnChange(float _, float pct)
        {
            loadingBar.fillAmount = pct;
            Color startColor = Color.red;
            Color endColor = Color.green;
            Color resultColor = Color.Lerp(startColor, endColor, pct);
            loadingBar.color = resultColor;
        }
    }
}