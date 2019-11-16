using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTile : Tile
{
    [Tooltip("The GameObject to active if the door is open.")]
    public GameObject doorOpen;

    [Tooltip("The GameObject to active if the door is closed")]
    public GameObject doorClosed;

    [Tooltip("Is this door opened at the start of the level? False for closed by default.")]
    public bool doorDefaultOpened = false;

    // State of the door: false if closed, true if opened
    private bool isDoorOpen;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Add this tile for tracking through the LevelGrid
        LevelGrid.CurrLevelGrid.AddTile(this.gameObject);

        // Initialize state
        isDoorOpen = doorDefaultOpened;
    }


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Update which sprite/gameobject is displayed depending on whether or not the door is open
        if (doorOpen != null)
            doorOpen.SetActive(isDoorOpen);

        if (doorClosed != null)
            doorClosed.SetActive(!isDoorOpen);
    }


    /// <summary>
    /// Reset this tile to its beginning state.
    /// </summary>
    public override void ResetTile()
    {
        base.ResetTile();

        // Reset state of the door
        isDoorOpen = doorDefaultOpened;
    }


    /// <summary>
    /// Whether or not another tile can go on top of this tile. 
    /// </summary>
    /// <returns></returns>
    public override bool CanGoThrough()
    {
        // Other tiles (ie player) can go through this tile if the door is open.
        return isDoorOpen;
    }


    #region EVENT HANDLERS


    /// <summary>
    /// 
    /// </summary>
    public void OpenDoor()
    {
        isDoorOpen = true;
    }


    public void CloseDoor()
    {
        isDoorOpen = false;
    }


    public void ToggleDoor()
    {
        isDoorOpen = !isDoorOpen;
    }

    #endregion
}
