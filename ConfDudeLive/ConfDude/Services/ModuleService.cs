using Contracts;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ConfDude.Services
{
    public class ModuleService : IModuleService
    {
        private CompositionContainer container;

        public ModuleService()
        {
            this.Compose();
        }

        private void Compose()
        {
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var catalog = new DirectoryCatalog(path);
            container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }

        public List<IModuleMetadata> GetMetadata()
        {
            var modules = container.GetExports<IModule, IModuleMetadata>();
            var list = new List<IModuleMetadata>();
            foreach (var lazy in modules)
            {
                list.Add(lazy.Metadata);
            }
            return list;
        }

        public IModule Activate(IModuleMetadata metadata)
        {
            var modules = container.GetExports<IModule, IModuleMetadata>();
            foreach (var lazy in modules)
            {
                if (lazy.Metadata.Name.Equals(metadata.Name))
                {
                    var module = lazy.Value;
                    module.Initialize(ServicePool.Current);
                    return module;
                }
            }
            return null;
        }
    }
}
