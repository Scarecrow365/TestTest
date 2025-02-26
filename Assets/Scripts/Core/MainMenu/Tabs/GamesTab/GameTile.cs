using System;
using _clone.Scripts.Data.MainMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.MainMenu.Tabs.GamesTab
{
    public class GameTile : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text gameName;

        private Action<string> onButtonPressed;
        
        private string id;

        private void Start()
        {
            button.onClick.AddListener(() => onButtonPressed?.Invoke(id));
        }

        public void SetGameInfo(TileGameData gameData)
        {
            SetId(gameData.Id);
            SetColor(gameData.Color);
            SetGameName(gameData.Name);
        }

        public void SetCallback(Action<string> onPressed) => onButtonPressed = onPressed;

        private void SetId(string gameDataId) => id = gameDataId;
        private void SetColor(Color gameDataColor) => image.color = gameDataColor;
        private void SetGameName(string gameName) => this.gameName.SetText(gameName);
    }
}