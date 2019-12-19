using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace UnityAppTest.Main
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            HomeWidget.InstallToContainer(Container);
            IncrementWidget.InstallToContainer(Container);
        }
    }
}
