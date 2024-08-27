using Microsoft.AspNetCore.Components;
using JJMasterData.Core.DataDictionary.Models;
using JJMasterData.Core.UI.Components;


namespace iPlug.Components.Pages
{
    public partial class DynamicForm2
    {

       /// <summary>
       /// [Inject]
       /// </summary>
       // private HttpClient Http { get; set; }


        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();   

            await client.GetAsync("https://localhost:7200/dynamicform");


           

        }
    }
}