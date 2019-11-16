using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Draggable : MonoBehaviour
{
    [SerializeField] private bool active = true;
    [SerializeField] private GameObject attachedTo;

    public GameObject AttachedTo
    {
        get => attachedTo;
        set
        {
            if (value)
            {
                attachedTo = value;
                return;
            }

            gameObject.GetComponent<DragHandler>().Parent = null;

            if (attachedTo)
            {
                InputNode input = attachedTo.GetComponent<InputNode>();
                ActionNode action = attachedTo.GetComponent<ActionNode>();

                if (input)
                    input.CurrentInput = null;
                else if (action)
                    action.CurrentAction = null;
            }
            attachedTo = value;

        }
    }

    /// <summary>
    /// Property telling whether or not the object is able to be dragged
    /// </summary>
    public bool Active
    {
        get => active;
        set
        {
            active = value;
            gameObject.GetComponent<DragHandler>().enabled = active;
        }
    }

    public string Text
    {
        get => gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        set => gameObject.GetComponentInChildren<TextMeshProUGUI>().text = value;
    }
}
