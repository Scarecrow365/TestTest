using System;
using UnityEngine.SceneManagement;

namespace _clone.Scripts.Services.SceneLoader
{
    public class SceneLoader : IService
    {
        public const string MainSceneName = "MainScene";
        public const string GameSceneName = "GameScene";

        public void LoadGameScene(LoadSceneMode sceneMode = LoadSceneMode.Single, Action onLoaded = null)
        {
            Load(GameSceneName, sceneMode, onLoaded);
        }

        public void LoadMainScene(LoadSceneMode sceneMode = LoadSceneMode.Single, Action onLoaded = null)
        {
            Load(MainSceneName, sceneMode, onLoaded);
        }

        public void Load(string sceneName, LoadSceneMode sceneMode, Action onLoaded = null)
        {
            if (sceneName == SceneManager.GetActiveScene().name)
                onLoaded?.Invoke();

            onLoaded?.Invoke();
        }

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}