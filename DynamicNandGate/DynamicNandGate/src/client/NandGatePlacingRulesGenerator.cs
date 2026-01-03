using JimmysUnityUtilities;
using LogicAPI.Data;
using LogicWorld.Rendering.Dynamics;
using LogicWorld.SharedCode.Components;
using UnityEngine;

// Change the namespace to your name + name of your mod + .Client
// ex: AuthorName_ModName.Client
namespace FoxFireFive_DynamicNandGate.Client
{
    public class NandGatePlacingRulesGenerator : DynamicPlacingRulesGenerator<int>
    {
        protected override int GetIdentifierFor(ComponentData componentData)
        {
            return componentData.InputCount;
        }

        protected override PlacingRules GeneratePlacingRulesFor(int inputCount)
        {
            PlacingRules placingRules = new PlacingRules();
            placingRules.AllowFineRotation = inputCount <= 2;

            if (inputCount == 3)
            {
                placingRules.GridPlacingDimensions = new Vector2Int(2, 2);
            }
            else
            {
                int x = ((float)inputCount / 2f - 0.01f).RoundToInt();
                placingRules.OffsetDimensions = new Vector2Int(x, 1);
                placingRules.GridPlacingDimensions = new Vector2Int(x, 2);
            }

            return placingRules;
        }
    }
}
