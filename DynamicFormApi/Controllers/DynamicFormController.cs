using Microsoft.AspNetCore.Mvc;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;
using JJMasterData.Commons.Data.Entity.Repository.Abstractions;
using JJMasterData.Commons.Data.Entity.Repository;

namespace DynamicFormApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamicFormController : Controller
    {


        private readonly IFormElementComponentFactory<JJFormView> _formViewFactory;
        private readonly IComponentFactory _componentFactory;
        private readonly IEntityRepository _entityRepository;



        public required string PanelViewHtml { get; set; }


        public DynamicFormController(ILogger<DynamicFormController> logger, IFormElementComponentFactory<JJFormView> formViewFactory, IComponentFactory componentFactory, IEntityRepository entityRepository)
        {
            _componentFactory = componentFactory;

        }
        [Route("getdynamicform"), HttpGet]
      //  [HttpGet(Name = "GetDynamicForm")]
        public async Task<string> GetDynamicForm()
        {
            var dataPanel = await GetDataPanel();

            var result = await dataPanel.GetResultAsync();

            /// Here we intercept any async POST request, like the form reload.
            //if (result is IActionResult actionResult)
            //    return actionResult;

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

      

        [HttpPost]
        public async Task<IActionResult> Save2()
        {
            var dataPanel = await GetDataPanel();
            var values = await dataPanel.GetFormValuesAsync();
            var errors = dataPanel.ValidateFields(values);

            if (errors.Count > 0)
            {
                dataPanel.Errors = errors;
                ViewData["ReturnMessage"] = _componentFactory.Html.ValidationSummary.Create(errors).GetHtml();
            }
            else
            {
                //Update values in Database
                await _entityRepository.InsertAsync(dataPanel.FormElement, values);

                var alert = _componentFactory.Html.Alert.Create();
                //alert.Color = PanelColor.Success;
                alert.Title = "Record updated";
                ViewData["ReturnMessage"] = alert.GetHtml();
            }
            var result = await dataPanel.GetResultAsync();
            PanelViewHtml = result.Content;

            return View("Index");
        }
    }
}
