using System;
using GameFramework.GameEventBus.EventDataTypes;
using GameFramework.GameReactiveProperty;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UI_Loading : MonoBehaviour
    {
        [SerializeField]
        private Image loadingBar;


        private GameReactivePropertyOldAndNew<float> progressBarPct;


        private void Start()
        {
            GameEventBus.AddListener<ED_LoadingProgressChanged>(ProgressChanged);
        }


        private void OnDestroy()
        {
            GameEventBus.RemoveListener<ED_LoadingProgressChanged>(ProgressChanged);
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
        }


        private void ChangeProgressBar(float pct)
        {
            if (progressBarPct == null) // if null then create new with initial value
            {
                progressBarPct = new()
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