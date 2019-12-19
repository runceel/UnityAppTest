using Unity.UIWidgets.widgets;
using Zenject;

namespace UnityAppTest
{
    public class ZenjectStatefulWidget<TSelf, TState> : StatefulWidget
        where TSelf : StatefulWidget
        where TState : State
    {
        [Inject]
        public DiContainer Container { get; set; }
        public override State createState() => Container.Resolve<TState>();

        public static void InstallToContainer(DiContainer container)
        {
            container.Bind<TSelf>().AsTransient();
            container.Bind<TState>().AsTransient();
        }
    }
}
