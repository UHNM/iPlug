using iPlug.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace iPlug.Components.Pages
{
    public partial class VentilationForm
    {
        [Inject]
        private IConfiguration configuration { get; set; }

        protected override async Task OnInitializedAsync()
        {

            var x = "hello";
        }

        private VentilationFormModel model { get; set; } = new VentilationFormModel();

        private async Task OnButtonClick(MouseEventArgs e)
        {
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
            var json = JsonConvert.SerializeObject(model,Formatting.None);
            var content = new StringContent(json, System.Text.Encoding.UTF8,"application/json");
            var url = configuration["DynamicFormsApiUrl"] + "/ventilation";
            var response = await client.PostAsync(url, content);
        }
    }



}
