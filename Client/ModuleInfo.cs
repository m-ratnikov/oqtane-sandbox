using Oqtane.Models;
using Oqtane.Modules;

namespace QB.Customer
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Customer",
            Description = "Customer",
            Version = "1.0.0",
            ServerManagerType = "QB.Customer.Manager.CustomerManager, QB.Customer.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "QB.Customer.Shared.Oqtane"
        };
    }
}
