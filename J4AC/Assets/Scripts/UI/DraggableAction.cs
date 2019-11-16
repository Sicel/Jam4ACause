using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DraggableAction : MonoBehaviour
{
    public GameEvent action;

    public TextMeshProUGUI TextMesh { get => gameObject.GetComponent<TextMeshProUGUI>(); }
}
