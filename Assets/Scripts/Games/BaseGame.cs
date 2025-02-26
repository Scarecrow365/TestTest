using System;
using System.Collections;
using UnityEngine;

namespace _clone.Scripts.Games
{
    public abstract class BaseGame : MonoBehaviour
    {
        private Action onGameComplete;
        private const int GameCountdown = 3;

        public abstract void Init();

        public void SetCallback(Action onGameComplete)
        {
            this.onGameComplete = onGameComplete;
        }

        public void Launch()
        {
            StartCoroutine(PreGameCountdown());
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Unpause()
        {
            throw new NotImplementedException();
        }

        public void PrepareForRestart()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            //stop any process
            throw new NotImplementedException();
        }

        private IEnumerator PreGameCountdown()
        {
            var timer = 0; 
            while (timer < GameCountdown)
            {
                yield return new WaitForSeconds(1);
                timer++;
            }
        }
    }
}