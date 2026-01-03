using EccsGuiBuilder.Client.Layouts.Elements;
using EccsGuiBuilder.Client.Layouts.Helper;
using EccsGuiBuilder.Client.Wrappers;
using EccsGuiBuilder.Client.Wrappers.AutoAssign;
using LogicAPI.Data.BuildingRequests;
using LogicUI.MenuParts;
using LogicWorld.BuildingManagement;
using LogicWorld.UI;
using System.Collections.Generic;

// Change the namespace to your name + name of your mod + .Client
// ex: AuthorName_ModName.Client
namespace FoxFireFive_DynamicNandGate.Client
{
    //This is a bit differant from the vanilla and gate, because it's GUI is hardcoded into the game.
    //Our NAND gate uses Ecconia's mods to help with creating the GUI.
    public class EditNandGateMenu : EditComponentMenu, IAssignMyFields
    {
        [AssignMe]
        public InputSlider InputCountSlider;

        // You should probably make this smaller.
        private static int MaxPegs { get; set; } = 256;

        public static void SetupGUI()
        {
            WS.window("FoxFireFive_NandGateMenu")
                .setYPosition(150)
                .configureContent(content => content
                    .layoutVerticalInnerCentered()
                    .add(WS.textLine
                        .setLocalizationKey("Input Count")
                    )

                    .add(WS.slider
                        .injectionKey(nameof(InputCountSlider))
                        .setInterval(1)
                        .setMin(2)
                        .setMax(MaxPegs)
                        .fixedSize(500, 45)
                    )
                )
                .add<EditNandGateMenu>()
                .build();
        }

        protected override void OnStartEditing()
        {
            InputCountSlider.SetValueWithoutNotify(
                FirstComponentBeingEdited.Component.Data.InputCount
            );
        }

        public override void Initialize()
        {
            base.Initialize();
            InputCountSlider.OnValueChangedInt += value =>
            {
                BuildRequestManager.SendBuildRequest(
                    new BuildRequest_ChangeDynamicComponentPegCounts(
                        FirstComponentBeingEdited.Address,
                        value,
                        1
                    )
                );
            };
        }

        protected override IEnumerable<string> GetTextIDsOfComponentTypesThatCanBeEdited()
        {
            yield return "FoxFireFive.DynamicNandGate.DynamicNandGate";
        }
    }
}