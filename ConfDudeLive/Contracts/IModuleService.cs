using System.Collections.Generic;

namespace Contracts
{
    public interface IModuleService
    {
        IModule Activate(Contracts.IModuleMetadata metadata);
        List<Contracts.IModuleMetadata> GetMetadata();
    }
}
