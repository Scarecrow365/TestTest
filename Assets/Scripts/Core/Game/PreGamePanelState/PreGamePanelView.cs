using System;
using _clone.Scripts.Data.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Game.PreGamePanelState
{
    public class PreGamePanelView : MonoBehaviour
    {
        [SerializeField] private Image gameLogo;
        [SerializeField] private TMP_Text gameName;
        [SerializeField] private TMP_Text gameDescription;
        [SerializeField] private Button playButton;
        [SerializeField] private Button exitButton;

        public event Action onPlay;
        public event Action onExit;
        
        private void Start()
        {
            playButton.onClick.AddListener(() => onPlay?.Invoke());
            exitButton.onClick.AddListener(() => onExit?.Invoke());
        }

        public void Init(PreGameData preGameData)
        {
            gameLogo.sprite = preGameData.logo;
            // gameName.SetText(preGameData.name);
            // gameDescription.SetText(preGameData.description);
        }

        public void SetSubscribes(Action onPlay, Action onExit)
        {
            this.onPlay = onPlay;
            this.onExit = onExit;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}