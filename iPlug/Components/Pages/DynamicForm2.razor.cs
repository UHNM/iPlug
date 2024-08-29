using Azure.Core.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace iPlug.Components.Pages
{
    public partial class DynamicForm2
    {
        [Inject]
        private IConfiguration configuration { get; set; }

        public static int InitialCount = 0;

        [ViewData]
        public  string PanelViewHtml { get; set; }
      
        protected override async Task OnInitializedAsync()
        {

            //if (InitialCount < 2)
            //{
            // InitialCount++;
                using HttpClient client = new HttpClient();
                var url = configuration["DynamicFormsApiUrl"] + "/getdynamicform";
                var response = await client.GetAsync(url);
                PanelViewHtml = await response.Content.ReadAsStringAsync();
                //IsIntial = true;

            //}


        }


        public async Task OnButtonClick(MouseEventArgs e)
        {
            HttpClient client = new HttpClient();

            var url = configuration["DynamicFormsApiUrl"] + "/save";
            var response = await client.PostAsync(url, null);

           


        }
    }
}