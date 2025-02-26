using _clone.Scripts.StateMachine;
using _clone.Scripts.StateMachine.States.Main;
using UnityEngine;

namespace _clone.Scripts.Core.Main
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Data.Data data;
        
        private BaseStateMachine mainStateMachine;

        private static Main instance;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this);

            data.Init();

            mainStateMachine = new MainStateMachine();
            mainStateMachine.Start();
        }
    }
}