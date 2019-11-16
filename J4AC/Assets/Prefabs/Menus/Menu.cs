using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool DefaultEnabled = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (DefaultEnabled)
            ShowMenu();
        else
            HideMenu();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void ShowMenu()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        // Invoke("ShowMenuWithDelay", 0.5f);
    }

    public void ShowMenuWithDelay()
    {
        Invoke("_ShowMenuWithDelay", 0.5f);
    }

    private void _ShowMenuWithDelay()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void HideMenu()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
