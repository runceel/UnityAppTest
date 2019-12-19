using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityAppTest.Base
{
    [RequireComponent(typeof(SceneLoader))]
    public class SceneLoaderExecuterOnStart : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<SceneLoader>().Execute();
        }
    }
}
