using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// An action node that will keep track of the current event and whether or not it's locked into place
/// </summary>
public class ActionNode : MonoBehaviour
{
    [SerializeField]
    private GameEvent actionEvent = null;
    [SerializeField]
    private bool locked = false;
    [SerializeField]
    private GameObject currentAction;

    /// <summary>
    /// Property to get and set the current action event
    /// </summary>
    public GameEvent ActionEvent
    {
        get { return actionEvent; }
        set
        {
            if(!locked)
            {
                actionEvent = value;
            }
        }
    }
    public string Text
    {
        get => gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        set => gameObject.GetComponentInChildren<TextMeshProUGUI>().text = value;
    }

    public DraggableAction CurrentAction
    {
        get => currentAction.GetComponent<DraggableAction>();
        set
        {
            if (locked)
                return;

            ActionEvent = value.action;
            Text = value.Text;
            if (currentAction)
            {
                currentAction.GetComponent<DragHandler>().ResetToParent();
                CurrentAction.Active = true;
            }
            currentAction = value.gameObject;
            value.Active = false;
        }
    }

    /// <summary>
    /// Function to trigger the game event for the action node
    /// </summary>
    public void TriggerAction()
    {
        if(actionEvent != null)
        {
            actionEvent.Raise();
        }
    }

    public void ResetAction()
    {
        Text = "Action";
        actionEvent = null;
        currentAction.GetComponent<DragHandler>().ResetToParent();
        CurrentAction.Active = true;
        currentAction = null;
    }
}
