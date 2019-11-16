using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static Vector3 mousePos;
    public static GameObject objectDragged;
    [SerializeField] private Transform contentTab;
    [SerializeField] private Transform nodesToolbar;

    private GraphicRaycaster GraphicRaycaster { get => nodesToolbar.GetComponentInParent<GraphicRaycaster>(); }

    private void Start()
    {
        //contentTab = transform.parent;
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
        ResetToParent();
    }

    public void ResetToParent()
    {
        transform.SetParent(contentTab);
        objectDragged = null;
    }
}
