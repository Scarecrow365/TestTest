using System;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Game.GameplayState.PauseMenu
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Button quitButton;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button restartButton;
        
        private Action onQuit;
        private Action onOpen;
        private Action onClose;
        private Action onRestart;

        private void Start()
        {
            button.onClick.AddListener(Open);
            quitButton.onClick.AddListener(Quit);
            closeButton.onClick.AddListener(Close);
            restartButton.onClick.AddListener(Restart);
        }

        public void SetCallbacks(Action onQuit, Action onClose, Action onOpen, Action onRestart)
        {
            this.onQuit = onQuit;
            this.onOpen = onOpen;
            this.onClose = onClose;
            this.onRestart = onRestart;
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        private void Open()
        {
            onOpen?.Invoke();
        }

        private void Close()
        {
            onClose?.Invoke();
        }

        private void Restart()
        {
            Close();
            onRestart?.Invoke();
        }

        private void Quit()
        {
            Close();
            onQuit?.Invoke();
        }
    }
}