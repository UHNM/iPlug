using Microsoft.AspNetCore.Components;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;


namespace iPlug.Components.Pages
{
    public partial class DynamicForm2
    {

        [Inject]
        private HttpClient Http { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await Http.GetAsync("api/dynamicform");


           

        }
    }
}