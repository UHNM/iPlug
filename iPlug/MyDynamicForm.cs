using JJMasterData.Core.UI.Components;

namespace iPlug
{
    public class MyDynamicForm
    {
        public IComponentFactory _componentFactory;
        public MyDynamicForm(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }


    }
}
