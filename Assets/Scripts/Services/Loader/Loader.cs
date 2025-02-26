using _clone.Scripts.Data.Loader;
using UnityEngine;

namespace _clone.Scripts.Services.Loader
{
    public class Loader : IService
    {
        private GameObject loader;

        public void Show()
        {
            CheckLoader();
            loader.SetActive(true);
        }

        public void Hide()
        {
            CheckLoader();
            loader.SetActive(false);
        }

        private void CheckLoader()
        {
            if (loader == null)
                loader = Data.Data.Container.Single<LoaderContainer>().MainMenuViewPrefab;
        }
    }
}