using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Draggable : MonoBehaviour
{
    [SerializeField] private bool active = true;

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
