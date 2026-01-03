using EccsLogicWorldAPI.Client.Hooks; // Contains code for adding hooks to Logic World, like the WorldHook used below.
using System;
using LogicWorld;
using LogicAPI.Client;

// Change the namespace to your name + name of your mod + .Client
// ex: AuthorName_ModName.Client
namespace FoxFireFive_DynamicNandGate.Client
{
    public class ClientLoader : ClientMod
    {
        protected override void Initialize()
        {
            // Add a hook to world loading, so when the world loads, the GUI for our component is built.
            WorldHook.worldLoading += () =>
            {
                try
                {
                    EditNandGateMenu.SetupGUI();
                }
                catch (Exception e)
                {
                    Logger.Error("Could not setup Dynamic NAND Gate Gui");
                    SceneAndNetworkManager.TriggerErrorScreen(e);
                }
            };

            Logger.Info("Dynamic NAND Gate - Client Loaded");
        }
    }
}
