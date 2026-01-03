using LogicAPI.Server.Components;

namespace FoxFireFive_DynamicNandGate.Server
{
    public class DynamicNandGate : LogicComponent
    {
        protected override void DoLogicUpdate()
        {
            for (int i = 0; i < base.Inputs.Count; i++)
            {
                if (!base.Inputs[i].On)
                {
                    base.Outputs[0].On = true;
                    return;
                }
            }
            base.Outputs[0].On = false;
        }
    }
}