using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// An input node that will keep track of an input key and a set of action nodes
/// </summary>
public class InputNode : MonoBehaviour
{
    [SerializeField]
    private KeyCode inputKey = KeyCode.None;
    [SerializeField]
    private ActionNode[] actionNodes = new ActionNode[0];
    [SerializeField]
    private GameObject currentInput;
    private WaitForSeconds wait = new WaitForSeconds(0.3f);

    public ActionNode[] ActionNodes { get => actionNodes; }
    public string Text
    {
        get => gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        set => gameObject.GetComponentInChildren<TextMeshProUGUI>().text = value;
    }

    public DraggableInput CurrentInput
    {
        get => currentInput.GetComponent<DraggableInput>();
        set
        {
            inputKey = value.key;
            Text = value.Text;
            currentInput = value.gameObject;
            currentInput.GetComponent<DragHandler>().EndDrag();
            if (currentInput)
                CurrentInput.Active = true;
            value.Active = false;
        }
    }

    /// <summary>
    /// Property to get and set the input key
    /// </summary>
    public KeyCode InputKey
    {
        get { return inputKey; }
        set { inputKey = value; }
    }

    /// <summary>
    /// Property to get the length of the action nodes array
    /// </summary>
    public int ActionNodeCount { get { return actionNodes.Length; } }

    /// <summary>
    /// Sets the action node at the given index
    /// </summary>
    /// <param name="index">The index in the array of action nodes</param>
    /// <param name="actionEvent">The game event for this action node</param>
    public void SetActionNode(int index, GameEvent actionEvent)
    {
        if(index >= 0 && index < actionNodes.Length)
        {
            actionNodes[index].ActionEvent = actionEvent;
        }
    }

    /// <summary>
    /// Method to ensure none of the actions have no event
    /// </summary>
    /// <returns>True if all action nodes have events; false otherwise</returns>
    public bool EnsureActionsAreFilled()
    {
        for(int i = 0; i < actionNodes.Length; i++)
        {
            if(actionNodes[i].ActionEvent == null)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Function to trigger the actions
    /// </summary>
    public void TriggerActions()
    {
        StartCoroutine(ActionsCoroutine());
    }

    /// <summary>
    /// Coroutine to trigger each action with a delay between them
    /// </summary>
    /// <returns>A coroutine</returns>
    private IEnumerator ActionsCoroutine()
    {
        for(int i = 0; i < actionNodes.Length; i++)
        {
            actionNodes[i].TriggerAction();
            yield return wait;
        }
    }
}
