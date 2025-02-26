using TMPro;
using UnityEngine;

namespace _clone.Scripts.Games.Memory.PathMemoryGame
{
    public class HudScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text timerText;
            
    }

    public class GameField : MonoBehaviour
    {
        
    }
    
    public class PathMemoryGame : BaseGame
    {
        [SerializeField] private GameField gameField;
        [SerializeField] private HudScreen hudScreen;
        
        public override void Init()
        {
            
        }
    }
}