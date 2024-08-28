using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace iPlug.Components.Pages
{
    public partial class DynamicForm2
    {
        [Inject]
        private IConfiguration configuration { get; set; }


        [ViewData]
        public  string PanelViewHtml { get; set; }
      
        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            var url = configuration["DynamicFormsApiUrl"];
            var response  = await client.GetAsync(url);
            PanelViewHtml = await response.Content.ReadAsStringAsync();
          

        }
    }
}