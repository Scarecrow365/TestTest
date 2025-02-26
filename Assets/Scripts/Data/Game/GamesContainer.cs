using _clone.Scripts.Core.Game.GameplayState.PauseMenu;
using _clone.Scripts.Core.Game.PreGamePanelState;
using UnityEngine;

namespace _clone.Scripts.Data.Game
{
    [CreateAssetMenu(fileName = nameof(GamesContainer), menuName = "MindGame/Data/" + nameof(GamesContainer))]
    public class GamesContainer: ScriptableObject, IData
    {
        [field: SerializeField] public PauseMenuView PauseMenuPrefab { get; private set; }
        [field: SerializeField] public PreGamePanelView PreGamePanelPrefab { get; private set; }

        [SerializeField] private BaseGameBundle amazeBundle;

        public bool TryGetGameBundleById(string gameId, out BaseGameBundle gameBundle)
        {
            if (amazeBundle != null && amazeBundle.Id == gameId)
            {
                gameBundle = amazeBundle;
                return true;
            }
            
            gameBundle = null;
            return false;
        }
    }
}