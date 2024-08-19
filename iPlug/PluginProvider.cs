using iPlug.PluginApi;

using Autofac;

namespace iPlug
{
    public sealed class PluginProvider
    {
        private readonly Lazy<IReadOnlyList<IPluginApi>> _lazyPlugins;

        public PluginProvider(Lazy<IEnumerable<IPluginApi>> lazyplugins) 
        {
         _lazyPlugins = new(lazyplugins.Value.ToArray());
        }

        public IReadOnlyList<IPluginApi> GetPlugins() 
        {
            
            return _lazyPlugins.Value;
        }
    }

    public sealed class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<PluginProvider>()
                .SingleInstance();

        }
    }
}
