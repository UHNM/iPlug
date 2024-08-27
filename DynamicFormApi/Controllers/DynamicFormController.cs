using Microsoft.AspNetCore.Mvc;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;
using JJMasterData.Commons.Data.Entity.Repository.Abstractions;

namespace DynamicFormApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormController : Controller
    {

       
        private readonly IComponentFactory _componentFactory;
     


        public required string PanelViewHtml { get; set; }


        public DynamicFormController(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;

        }

        [HttpGet(Name = "GetDynamicForm")]
        public async Task<string> Get()
        {
            var dataPanel = await GetDataPanel();

            var result = await dataPanel.GetResultAsync();

            /// Here we intercept any async POST request, like the form reload.
            //if (result is IActionResult actionResult)
            //    return actionResult;

            PanelViewHtml = result.Content;

            return PanelViewHtml;
        }

        private async Task<JJDataPanel> GetDataPanel()
        {
            var dataPanel = await _componentFactory.DataPanel.CreateAsync("Ventilation");
            dataPanel.PageState = PageState.Update; // You can change here to PageState.Insert if you want.
            return dataPanel;
        }
    }
}
