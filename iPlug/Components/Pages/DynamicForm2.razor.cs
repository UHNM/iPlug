using Microsoft.AspNetCore.Components;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;
using Microsoft.AspNetCore.Mvc;


namespace iPlug.Components.Pages
{
    public partial class DynamicForm2
    {
        [ViewData]
        public  string PanelViewHtml { get; set; }
        /// <summary>
        /// [Inject]
        /// </summary>
        // private HttpClient Http { get; set; }


        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();

            var response  = await client.GetAsync("http://localhost:5260/dynamicform");
            PanelViewHtml = await response.Content.ReadAsStringAsync();
          

        }
    }
}