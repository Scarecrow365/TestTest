using System.Collections.Generic;
using System.Linq;
using _clone.Scripts.Core.MainMenu;
using _clone.Scripts.Core.MainMenu.Tabs;
using UnityEngine;

namespace _clone.Scripts.Data.MainMenu
{
    [CreateAssetMenu(fileName = nameof(MainMenuContainer), menuName = "MindGame/View/" + nameof(MainMenuContainer))]
    public class MainMenuContainer : ScriptableObject, IData
    {
        [field: SerializeField] public MainScreenView MainScreenPrefab { get; private set; }
        [field: SerializeField] public GamesTabContainer GamesTabContainer { get; private set; }

        [SerializeField] private List<BaseTabNode> prefabs;

        public TTab GetTabPrefab<TTab>()
        {
            foreach (var prefab in prefabs.OfType<TTab>())
            {
                return prefab;
            }

            return default;
        }
    }
}