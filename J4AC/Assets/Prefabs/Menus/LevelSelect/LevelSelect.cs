using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : Menu
{
    // Singleton
    public static LevelSelect ActiveLevelSelectMenu { get; private set; }

    public GameObject DropdownObject;
    private TMPro.TMP_Dropdown dropdown;

    public int CurrLevel;

    private int level;

    private void Awake()
    {
        ActiveLevelSelectMenu = this;

        if (DropdownObject != null)
            dropdown = DropdownObject.GetComponent<TMPro.TMP_Dropdown>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        level = CurrLevel;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

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
        Debug.Log("Loading level " + level + ".\n");

        SceneManager.LoadScene("Level" + level);
    }
}
