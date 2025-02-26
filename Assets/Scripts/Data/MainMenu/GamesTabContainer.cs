using UnityEngine;
using _clone.Scripts.Core.MainMenu.Tabs.GamesTab;

namespace _clone.Scripts.Data.MainMenu
{
    [CreateAssetMenu(fileName = nameof(GamesTabContainer), menuName = "MindGame/View/" + nameof(GamesTabContainer))]
    public class GamesTabContainer : ScriptableObject
    {
        [field: SerializeField] public GameTile GameTilePrefab { get; private set; }
        [field: SerializeField] public DomainRoot DomainRoot { get; private set; }
        
        [SerializeField] private DomainData[] domainsData;

        public int DomainsDataCount => domainsData.Length;

        public DomainData GetDomainData(int index) => domainsData[index];
    }
}