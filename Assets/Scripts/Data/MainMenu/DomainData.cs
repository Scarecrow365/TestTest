using _clone.Scripts.Constants;
using UnityEngine;

namespace _clone.Scripts.Data.MainMenu
{
    [CreateAssetMenu(fileName = nameof(DomainData), menuName = "MindGame/Data/" + nameof(DomainData))]
    public class DomainData : ScriptableObject
    {
        [SerializeField] private Domain domain;
        [SerializeField] private TileGameData[] gamesData;

        public int GamesCount => gamesData.Length;
        
        public string GetName() => domain.ToString();

        public TileGameData GetGameData(int index) => gamesData[index];
    }
}