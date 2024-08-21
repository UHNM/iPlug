using Microsoft.AspNetCore.Mvc;

using JJMasterData.Commons.Data.Entity.Repository.Abstractions;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using JJMasterData.Commons.Data.Entity.Repository;
using Azure.Core;


namespace iPlug.Components.Pages
{
    public partial class DynamicForm 
    {
        [Microsoft.AspNetCore.Components.Inject]
        public MyDynamicForm myForm { get; set; }


        private readonly IComponentFactory?_componentFactory;
        //private IService service;

        //[Microsoft.AspNetCore.Components.Inject]
        //public IComponentFactory myComponentFactory { get; set; }

        MyDynamicForm? myDynamicForm;

        public required string PanelViewHtml { get; set; }
     


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(100);

            //var dataPanel = await GetDataPanel();
            //var result = await dataPanel.GetResultAsync();
            ////if (result is IActionResult actionResult)
            ////    return actionResult;
            var PanelViewHtml = myForm.DoStuff();


        }


        //private async Task<JJDataPanel> GetDataPanel()
        //{
        //    var dataPanel = await myForm._componentFactory.DataPanel.CreateAsync("Ventilation");
        //    dataPanel.PageState = PageState.Update; // You can change here to PageState.Insert if you want.
        //    return dataPanel;
        //}
    }
}