using Microsoft.AspNetCore.Mvc;

using JJMasterData.Commons.Data.Entity.Repository.Abstractions;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using JJMasterData.Commons.Data.Entity.Repository;


namespace iPlug.Components.Pages
{
    public partial class DynamicForm 
    {
        //private readonly ILogger<DynamicForm> _logger;
        private readonly IComponentFactory?_componentFactory;
        //private IService service;

        //[Microsoft.AspNetCore.Components.Inject]
        //public IComponentFactory myComponentFactory { get; set; }

        //MyDynamicForm myDynamicForm;

        public required string PanelViewHtml { get; set; }

        public DynamicForm(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
    
        }
        public DynamicForm()
        {
            
        }

       

        protected override async Task OnInitializedAsync()
        {
            
            var dataPanel = await GetDataPanel();
            var result = await dataPanel.GetResultAsync();
            //if (result is IActionResult actionResult)
            //    return actionResult;
            PanelViewHtml = result.Content;

        }


        private async Task<JJDataPanel> GetDataPanel()
        {
            var dataPanel = await myForm._componentFactory.DataPanel.CreateAsync("Ventilation");
            dataPanel.PageState = PageState.Update; // You can change here to PageState.Insert if you want.
            return dataPanel;
        }
    }
}