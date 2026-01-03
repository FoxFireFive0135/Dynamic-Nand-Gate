using LogicAPI.Server;

namespace FoxFireFive_DynamicNandGate.Server
{
    public class ServerLoader : ServerMod
    {
        protected override void Initialize()
        {
            this.Logger.Info("Dynamic NAND Gate has been initialized!");
            // useful for extra, per-mod setup stuff (this is called right after the mod was loaded)
        }
    }
}
