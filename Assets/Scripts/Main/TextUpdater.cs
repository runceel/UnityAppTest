using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UnityAppTest.Main
{
    public class TextUpdater : MonoBehaviour
    {
        [Inject]
        public Counter Counter { get; set; }

        private Text _text;

        private void Start()
        {
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _text.text = $"The counter value is {Counter.Value}";
        }
    }
}
