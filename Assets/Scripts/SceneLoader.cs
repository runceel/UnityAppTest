using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityAppTest
{
    public class SceneLoader : MonoBehaviour
    {
        public string UnloadSceneName;
        public string LoadSceneName;

        public void Execute() => StartCoroutine(ExecuteImpl());

        private IEnumerator ExecuteImpl()
        {
            yield return SceneManager.LoadSceneAsync(LoadSceneName, LoadSceneMode.Additive);
            if (!string.IsNullOrWhiteSpace(UnloadSceneName))
            {
                yield return SceneManager.UnloadSceneAsync(UnloadSceneName);
            }
        }
    }
}
