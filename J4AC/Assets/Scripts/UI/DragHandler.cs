using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static Vector3 mousePos;
    public static GameObject objectDragged;
    [SerializeField] private GameObject draggables;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform contentTab;
    [SerializeField] private Transform nodesToolbar;

    public Transform Parent
    {
        get => parent;
        set
        {
            parent = value;

            if (!parent)
            {
                parent = contentTab;
            }

            //transform.SetParent(parent);
        }
    }

    public Transform ContentTab { get => contentTab; }
    public GameObject Draggables { get => draggables; }

    private GraphicRaycaster GraphicRaycaster { get => nodesToolbar.GetComponentInParent<GraphicRaycaster>(); }

    private void Start()
    {
        parent = contentTab;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        objectDragged = gameObject;

        transform.SetParent(nodesToolbar);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //ResetToContent();
        ResetToParent();
    }

    public void ResetToContent()
    {
        parent = contentTab;
        ResetToParent();
    }

    public void ResetToParent()
    {
        transform.SetParent(parent);
        if (parent != contentTab)
            gameObject.transform.position = parent.position;

        objectDragged = null;
    }
}
