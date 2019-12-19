using Zenject;

namespace UnityAppTest
{
    public class BaseInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Counter>().AsSingle();
        }
    }

    public class Counter
    {
        public int Value { get; private set; }

        public void Increment() => Value++;
    }
}
