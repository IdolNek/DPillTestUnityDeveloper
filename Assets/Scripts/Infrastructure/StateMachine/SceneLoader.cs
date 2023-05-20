using Assets.Scripts.Infrastructure;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachine
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string nameScene, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(nameScene, onLoaded));

        private IEnumerator LoadScene(string nameScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nameScene)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nameScene);
            while (!waitNextScene.isDone)
            {
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }
}