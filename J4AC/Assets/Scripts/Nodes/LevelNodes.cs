using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNodes : MonoBehaviour
{
    [SerializeField]
    private InputNode[] inputNodes = new InputNode[0];
    [SerializeField]
    private TextMeshProUGUI playPauseText = null;
    private bool checkingForInput = true;
    private Coroutine activeGameCoroutine;

    public InputNode[] InputNodes { get => InputNodes; }

    /// <summary>
    /// Starts the active game coroutine
    /// </summary>
    public void PlayGame()
    {
        if(playPauseText)
        {
            playPauseText.text = "Playing";
        }
        activeGameCoroutine = StartCoroutine(GameActive());
    }

    /// <summary>
    /// Stops the active game coroutine
    /// </summary>
    public void PauseGame()
    {
        if (playPauseText)
        {
            playPauseText.text = "Paused";
        }
        StopCoroutine(activeGameCoroutine);
    }

    /// <summary>
    /// Enumerator that will check for input (while the game is playing and another action is not currently occurring)
    /// It will trigger any actions properly set up
    /// </summary>
    /// <returns>An enumerator</returns>
    private IEnumerator GameActive()
    {
        while(true)
        {
            if (checkingForInput)
            {
                //Check to see if any of the input nodes have their input pressed
                for (int i = 0; i < inputNodes.Length; i++)
                {
                    if (inputNodes[i].InputKey != KeyCode.None)
                    {
                        //If the input node's key is pressed and the actions are filled, trigger them
                        if (Input.GetKeyDown(inputNodes[i].InputKey) && inputNodes[i].EnsureActionsAreFilled())
                        {
                            checkingForInput = false;
                            inputNodes[i].TriggerActions();
                            Invoke("ReEnableInput", (0.3f * inputNodes[i].ActionNodeCount) + 0.01f);
                            break;
                        }
                    }
                }
            }
            yield return null;
        }
    }

    /// <summary>
    /// Method to re-enable input (used by invoke functionality)
    /// </summary>
    private void ReEnableInput()
    {
        checkingForInput = true;
    }

    public void ResetNodes()
    {
        foreach (InputNode input in inputNodes)
        {
            input.ResetInput();
        }

        PauseGame();
    }
}
