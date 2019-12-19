using UnityEngine;
using Zenject;

namespace UnityAppTest.Next
{
    public class Incrementer : MonoBehaviour
    {
        [Inject]
        public Counter Counter { get; set; }

        public void Execute() => Counter.Increment();
    }
}

