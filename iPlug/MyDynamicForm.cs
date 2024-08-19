using JJMasterData.Core.UI.Components;

namespace iPlug
{
    public class MyDynamicForm
    {
        private readonly IComponentFactory _componentFactory;
        public MyDynamicForm(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }
    }
}
