using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using UniRx.Async;

namespace UnityAppTest.Main
{
    public class CounterApp : UIWidgetsPanel
    {
        [Inject]
        public DiContainer Container { get; set; }
        protected override void OnEnable()
        {
            Screen.fullScreen = false;
            FontManager.instance.addFont(Resources.Load<Font>(path: "fonts/MaterialIcons-Regular"), "Material Icons");
            base.OnEnable();
        }

        protected override Widget createWidget()
        {
            if (Container == null)
            {
                return new MaterialApp(home: new Scaffold());
            }

            return new MaterialApp(
                home: Container.Resolve<HomeWidget>(),
                routes: new Dictionary<string, WidgetBuilder>
                {
                    ["/increment"] = ctx => Container.Resolve<IncrementWidget>(),
                }
            );
        }
    }

    class HomeWidget : ZenjectStatefulWidget<HomeWidget, HomeState>
    {
    }

    class HomeState : State<HomeWidget>
    {
        [Inject]
        public Counter Counter { get; set; }
        public override Widget build(BuildContext context)
        {
            return new Theme(
                data: new ThemeData(),
                child: new Scaffold(
                    appBar: new AppBar(
                        title: new Text(data: "Counter app"),
                        actions: new List<Widget>
                        {
                            new IconButton(
                                icon: new Icon(Icons.navigate_next),
                                onPressed: () => Navigator.of(context).pushNamed("/increment")
                            ),
                            new IconButton(
                                icon: new Icon(Icons.web),
                                onPressed: async () =>
                                {
                                    await SceneManager.LoadSceneAsync("next", LoadSceneMode.Additive);
                                    await SceneManager.UnloadSceneAsync("main");
                                }
                            )
                        }
                    ),
                    body: new Container(
                        padding: EdgeInsets.all(20),
                        child: new Text(data: $"This is a sample: {Counter.Value}")
                    ),
                    floatingActionButton: new FloatingActionButton(
                        tooltip: "Increment",
                        child: new Icon(Icons.add),
                        onPressed: () => {
                            setState(() => Counter.Increment());
                        }
                    )
                )
            );
        }
    }

    class IncrementWidget : ZenjectStatefulWidget<IncrementWidget, IncrementState>
    {
    }

    class IncrementState : State<IncrementWidget>
    {
        [Inject]
        public Counter Counter { get; set; }

        public override Widget build(BuildContext context)
        {
            return new Theme(
                data: new ThemeData(),
                child: new Scaffold(
                    appBar: new AppBar(
                        title: new Text(data: "Increment"),
                        leading: new IconButton(icon: new Icon(Icons.arrow_back), onPressed: () => Navigator.pop(context))
                    ),
                    body: new Container(
                        padding: EdgeInsets.all(20),
                        child: new Column(
                            children: new List<Widget>
                            {
                                new IconButton(icon: new Icon(Icons.add), tooltip: "Increment", onPressed: () => setState(() => Counter.Increment()))
                            }
                        )
                    )
                )
            );
        }
    }
}
