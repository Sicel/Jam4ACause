﻿using System.Collections;
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
        get
        {
            if (currentAction)
                return currentAction.GetComponent<DraggableAction>();

            return null;
        }
        set
        {
            if (locked)
                return;

            if (!value)
            {
                ResetAction();
                return;
            }

            Text = value.Text;
            if (currentAction)
            {
                currentAction.GetComponent<DragHandler>().ResetToContent();
                CurrentAction.AttachedTo = null;
            }
            currentAction = value.gameObject;
            value.AttachedTo = gameObject;
            ActionEvent = value.action;
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
        //Text = "Action";
        actionEvent = null;
        if (currentAction)
        {
            currentAction.GetComponent<DragHandler>().ResetToContent();
            CurrentAction.Active = true;
        }
        currentAction = null;
    }
}
