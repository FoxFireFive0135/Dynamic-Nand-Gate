using System.Collections.Generic;
using JimmysUnityUtilities;
using LogicAPI.Data;
using LogicWorld.Rendering.Dynamics;
using LogicWorld.SharedCode.Components;
using UnityEngine;

// Change the namespace to your name + name of your mod + .Client
// ex: AuthorName_ModName.Client
namespace FoxFireFive_DynamicNandGate.Client
{
    public class NandGatePrefabGenerator : DynamicPrefabGenerator<int>
    {
        private static readonly Color24 BlockColor = new Color24(255, 143, 79); // tan-ish orange color

        protected override int GetIdentifierFor(ComponentData componentData)
        {
            return componentData.InputCount;
        }

        //You want this to be the minimum for your component. In our case, we want it to be like the AND gate, minimum 2 inputs and 1 output.
        public override (int inputCount, int outputCount) GetDefaultPegCounts()
        {
            return (inputCount: 2, outputCount: 1);
        }

        protected override Prefab GeneratePrefabFor(int inputCount)
        {
            List<ComponentInput> prefabInputs = new List<ComponentInput>();

            Block prefabBlock = new Block
            {
                RawColor = BlockColor
            };

            ComponentOutput prefabOutput = new ComponentOutput
            {
                Rotation = new Vector3(90f, 0f, 0f)
            };

            if (inputCount == 3)
            {
                setBlockScaleX(1.5f);
                setOutputPositionX(0f);
                addInput(-0.5f);
                addInput(0f);
                addInput(0.5f);
            }
            else
            {
                float num = Mathf.Ceil((float)inputCount / 2f - 0.01f);
                float num2 = (num - 1f) / 2f;

                setBlockScaleX(num);
                setBlockPositionX(num2);
                setOutputPositionX(num2);

                float num3 = (num - 0.5f) / ((float)inputCount - 1f);

                for (int i = 0; i < inputCount; i++)
                {
                    addInput(-0.25f + (float)i * num3);
                }
            }

            Prefab prefab = new Prefab
            {
                Blocks = new Block[1] { prefabBlock },
                Outputs = new ComponentOutput[1] { prefabOutput },
                Inputs = prefabInputs.ToArray()
            };

            // Since this is a NAND gate, we want the output to start on.
            prefab.Outputs[0].StartOn = true;

            return prefab;

            // helper functions
            void addInput(float xPosition)
            {
                prefabInputs.Add(new ComponentInput
                {
                    Position = new Vector3(xPosition, 0.5f, -0.5f),
                    Rotation = new Vector3(-90f, 0f, 0f),
                    Length = 0.62f
                });
            }

            void setBlockPositionX(float blockPositionX)
            {
                prefabBlock.Position = new Vector3(blockPositionX, 0f, 0f);
            }

            void setBlockScaleX(float blockScaleX)
            {
                prefabBlock.Scale = new Vector3(blockScaleX, 1f, 1f);
            }

            void setOutputPositionX(float outputPositionX)
            {
                prefabOutput.Position = new Vector3(outputPositionX, 0.5f, 0.5f);
            }
        }
    }
}
