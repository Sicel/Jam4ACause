using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DraggableInput : MonoBehaviour
{
    public KeyCode key;

    public TextMeshProUGUI TextMesh { get => gameObject.GetComponent<TextMeshProUGUI>(); }
}
