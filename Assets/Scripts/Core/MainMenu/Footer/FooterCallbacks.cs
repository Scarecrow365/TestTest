using System;

namespace _clone.Scripts.Core.MainMenu.Footer
{
    public class FooterCallbacks
    {
        public event Action Main;
        public event Action Activity;
        public event Action Games;
        public event Action Stats;
        public event Action Profile;

        public void FireMain()
        {
            Main?.Invoke();
        }

        public void FireActivity()
        {
            Activity?.Invoke();
        }

        public void FireGames()
        {
            Games?.Invoke();
        }

        public void FireStats()
        {
            Stats?.Invoke();
        }

        public void FireProfile()
        {
            Profile?.Invoke();
        }
    }
}