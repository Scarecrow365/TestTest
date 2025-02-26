using _clone.Scripts.Constants.GamesId;
using UnityEngine;

namespace _clone.Scripts.Data.Game.Amaze
{
    [CreateAssetMenu(fileName = nameof(AmazeBundle), menuName = "MindGame/GamesBundles/" + nameof(AmazeBundle))]
    public class AmazeBundle : BaseGameBundle
    {
        public override string Id => MemoryGames.AmazeId;
    }
}