using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static Vector3 mousePos;
    public static GameObject objectDragged;
    public static GameObject gameObjectHit;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform nodesToolbar;
    [SerializeField] private CanvasGroup solutions;

    private GraphicRaycaster GraphicRaycaster { get => nodesToolbar.GetComponentInParent<GraphicRaycaster>(); }

    public void OnBeginDrag(PointerEventData eventData)
    {
        objectDragged = gameObject;

        transform.SetParent(nodesToolbar);
        gameObjectHit = null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }
    
    public void EndDrag()
    {
        transform.SetParent(parent);
        objectDragged = null;
    }
}
