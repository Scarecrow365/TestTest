using _clone.Scripts.Core.MainMenu.Footer;
using UnityEngine;

namespace _clone.Scripts.Core.MainMenu
{
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private FooterBar footerBar;
        [SerializeField] private Transform container;
        [SerializeField] private Transform containerNoBar;

        public Transform Root => container;
        public Transform RootNoBar => containerNoBar;

        public void SetCallbacks(FooterCallbacks footerCallbacks)
        {
            footerBar.SetCallbacks(footerCallbacks);
        }

        public void Run()
        {
            footerBar.Show();
        }

        public void Dispose()
        {
            footerBar.Dispose();
        }
    }
}