

using Autofac;

namespace PluginALibrary
{
    public sealed class PluginAModule : Module
    {
        // use reflection to iterate thru the assemblies and look for everything that is iPluginApi to avoid adding AutoFac to all the plugins as a nuget package
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PluginA>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
