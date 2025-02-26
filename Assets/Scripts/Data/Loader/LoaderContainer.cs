using UnityEngine;

namespace _clone.Scripts.Data.Loader
{
    [CreateAssetMenu(fileName = nameof(LoaderContainer), menuName = "MindGame/View/" + nameof(LoaderContainer))]
    public class LoaderContainer : ScriptableObject, IData
    {
        [SerializeField] private GameObject loader;

        public GameObject MainMenuViewPrefab => loader;
    }
}