﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : Menu
{
    public GameObject DropdownObject;
    private TMPro.TMP_Dropdown dropdown;

    int level;

    private void Awake()
    {
        if (DropdownObject != null)
            dropdown = DropdownObject.GetComponent<TMPro.TMP_Dropdown>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Dropdown.value is the index of the selection, so 0 = Level 1.
        if (dropdown != null)
            level = dropdown.value + 1;
    }

    public void SetNextLevel(int level)
    {
        this.level = level;
    }

    public void LoadLevel()
    {
        // @todo
        Debug.Log("Loading level " + level + ".\n");

        SceneManager.LoadScene("Level" + level);
    }
}