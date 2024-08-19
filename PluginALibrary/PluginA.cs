using iPlug.PluginApi;

namespace PluginALibrary
{
    public sealed class PluginA : IPluginApi
    {
     
        public async Task<string> GetDataAsync() => await Task.FromResult("Data from plugin A!");
    }
}
