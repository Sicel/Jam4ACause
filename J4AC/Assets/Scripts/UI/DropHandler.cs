using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    private GameObject objectDroppedOn;
    private GameObject objectDropped;
    public static GameObject lastDropped;
    private LevelNodes LevelNodes { get => gameObject.GetComponent<LevelNodes>(); }
    private GraphicRaycaster GraphicRaycaster { get => gameObject.GetComponentInParent<GraphicRaycaster>(); }

    public void OnDrop(PointerEventData eventData)
    {
        objectDroppedOn = null;
        CheckChildren(eventData);

        if (!objectDroppedOn)
            return;

        InputNode inputNode = objectDroppedOn.GetComponent<InputNode>();
        ActionNode actionNode = objectDroppedOn.GetComponent<ActionNode>();
        DraggableInput draggableInput = objectDropped.GetComponent<DraggableInput>();
        DraggableAction draggableAction = objectDropped.GetComponent<DraggableAction>();

        if (draggableAction)
        {
            if (!actionNode)
                return;

            actionNode.CurrentAction = draggableAction;
        }
        else if (draggableInput)
        {
            if (!inputNode)
                return;

            inputNode.CurrentInput = draggableInput;
        }
    }

    private void CheckChildren(PointerEventData eventData)
    {
        objectDropped = DragHandler.objectDragged;
        List<RaycastResult> results = new List<RaycastResult>();
        GraphicRaycaster.Raycast(eventData, results);

        foreach (RaycastResult result in results)
        {
            InputNode inputNode = result.gameObject.GetComponent<InputNode>();
            ActionNode actionNode = result.gameObject.GetComponent<ActionNode>();

            if (!inputNode && !actionNode)
                continue;

            objectDroppedOn = result.gameObject;
        }
    }
}
