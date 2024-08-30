using Microsoft.AspNetCore.Mvc;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;
namespace DynamicFormApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormController : Controller
    {
        private readonly IFormElementComponentFactory<JJFormView> _formViewFactory;
        private readonly IComponentFactory _componentFactory;
        public required string PanelViewHtml { get; set; }
        public required string FormViewHtml { get; set; }

        public DynamicFormController(IComponentFactory componentFactory)
        {
            _componentFactory = componentFactory;
        }
        [Route("getdynamicform"), HttpGet]
        public async Task<string> GetDynamicForm()
        {
             var dataPanel = await GetDataPanel();
             var result = await dataPanel.GetResultAsync();
             PanelViewHtml = result.Content;
            return PanelViewHtml;
        }
        [Route("save"), HttpPost]
        public async Task<IActionResult> Save()
        {
            var dataPanel = await GetDataPanel();
            var values = await dataPanel.GetFormValuesAsync();

            return Ok(values);
        }

        private async Task<JJDataPanel> GetDataPanel()
        {
            var dataPanel = await _componentFactory.DataPanel.CreateAsync("Ventilation");
            dataPanel.PageState = PageState.Update; // You can change here to PageState.Insert if you want.
            return dataPanel;
        }
    }
}
