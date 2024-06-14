using Game.Core.GameEventBusVariants.EventDataTypes;
using Game.Core.StateMachineVariants.States;
using GameFramework.GameEventBus;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UI_MainMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject parent;

        [SerializeField]
        private Button buttonStart;

        [SerializeField]
        private Button buttonOption1;

        [SerializeField]
        private Button buttonOption2;

        [SerializeField]
        private Button buttonQuit;


        private void Start()
        {
            buttonStart.onClick.AddListener(StartClick);
            buttonOption1.onClick.AddListener(Option1Click);
            buttonOption2.onClick.AddListener(Option2Click);
            buttonQuit.onClick.AddListener(QuitClick);

            GameEventBus.AddListener<ED_GameStateChanged>(GameStateChanged);
        }


        private void OnDestroy()
        {
            buttonStart.onClick.RemoveAllListeners();
            buttonOption1.onClick.RemoveAllListeners();
            buttonOption2.onClick.RemoveAllListeners();
            buttonQuit.onClick.RemoveAllListeners();

            GameEventBus.RemoveListener<ED_GameStateChanged>(GameStateChanged);
        }


        private void GameStateChanged(ED_GameStateChanged eventData)
        {
            var newState = eventData.NewState;
            bool gameStarted = newState == typeof(State_WaitingForGameStart);
            if (gameStarted)
            {
                ChangeUiState(false);
            }
        }


        private void ChangeUiState(bool uiActive)
        {
            parent.SetActive(uiActive);
        }


        private void StartClick()
        {
            new ED_StartClick().TriggerEvent();
        }


        private void Option1Click()
        {
        }

        private void Option2Click()
        {
        }

        private void QuitClick()
        {
        }
    }
}