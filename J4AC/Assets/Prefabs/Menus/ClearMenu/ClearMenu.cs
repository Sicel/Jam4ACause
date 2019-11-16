using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMenu : Menu
{
    public GameEvent ResetEvent;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void ReplayLevel()
    {
        // Throw reset events
        if (ResetEvent != null)
            ResetEvent.Raise();

        HideMenu();
    }

    public void OpenLevelSelect()
    {
        LevelSelect.ActiveLevelSelectMenu.ShowMenu();
        HideMenu();
    }

    public void NextLevel()
    {
        LevelSelect.ActiveLevelSelectMenu.SetNextLevel(LevelSelect.ActiveLevelSelectMenu.CurrLevel + 1);
        LevelSelect.ActiveLevelSelectMenu.LoadLevel();
    }
}
