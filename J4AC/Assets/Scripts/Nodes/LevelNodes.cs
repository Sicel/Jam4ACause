using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNodes : MonoBehaviour
{
    [SerializeField]
    private InputNode[] inputNodes = new InputNode[0];
    private bool checkingForInput = false;

    private void Update()
    {
        if(checkingForInput)
        {
            //Check to see if any of the input nodes have their input pressed
            for(int i = 0; i < inputNodes.Length; i++)
            {
                if(inputNodes[i].InputKey != KeyCode.None)
                {
                    //If the input node's key is pressed and the actions are filled, trigger them
                    if(Input.GetKeyDown(inputNodes[i].InputKey) && inputNodes[i].EnsureActionsAreFilled())
                    {
                        checkingForInput = false;
                        inputNodes[i].TriggerActions();
                        Invoke("ReEnableInput", (0.3f * inputNodes[i].ActionNodeCount) + 0.1f);
                        return;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Method to re-enable input (used by invoke functionality)
    /// </summary>
    private void ReEnableInput()
    {
        checkingForInput = true;
    }
}
