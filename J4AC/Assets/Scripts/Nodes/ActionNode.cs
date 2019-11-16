using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An action node that will keep track of the current event and whether or not it's locked into place
/// </summary>
public class ActionNode : MonoBehaviour
{
    [SerializeField]
    private GameEvent actionEvent = null;
    [SerializeField]
    private bool locked = false;

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
}
