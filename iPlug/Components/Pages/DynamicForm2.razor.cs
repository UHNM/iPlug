using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
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
           var url = configuration["DynamicFormsApiUrl"] + "/getdynamicform";
           var response = await client.GetAsync(url);
           PanelViewHtml = await response.Content.ReadAsStringAsync();
     
        }
        public async Task OnButtonClick(MouseEventArgs e)
        {
            HttpClient client = new HttpClient();
            var url = configuration["DynamicFormsApiUrl"] + "/save";
            var response = await client.PostAsync(url, null);

        }
    }
}