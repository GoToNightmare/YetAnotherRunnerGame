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
        }


        private void OnDestroy()
        {
            buttonStart.onClick.RemoveAllListeners();
            buttonOption1.onClick.RemoveAllListeners();
            buttonOption2.onClick.RemoveAllListeners();
            buttonQuit.onClick.RemoveAllListeners();
        }


        private void StartClick()
        {
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