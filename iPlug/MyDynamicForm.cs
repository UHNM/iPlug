using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;
using Microsoft.IdentityModel.Tokens;

namespace iPlug
{
    public class MyDynamicForm
    {
        public IComponentFactory _componentFactory;
       

        public MyDynamicForm(IComponentFactory componentFactory)
        {
           
            _componentFactory = componentFactory;


        }



        private async Task<JJDataPanel> GetDataPanel()
        {
            // IComponentFactory c = new ComponentFactory();
           
            var dataPanel = await _componentFactory.DataPanel.CreateAsync("Ventilation");
            dataPanel.PageState = PageState.Update; // You can change here to PageState.Insert if you want.
            return dataPanel;
        }

        public async Task<string> DoStuff()
        {
            var dataPanel = await GetDataPanel();
            var result = await dataPanel.GetResultAsync();
            
             return result.Content;
        }



    }
}
