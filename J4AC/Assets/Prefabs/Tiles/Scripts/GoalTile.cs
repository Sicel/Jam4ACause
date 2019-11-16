using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTile : Tile
{

    [Tooltip("The GameEvent to raise when the player has reached me.")]
    public GameEvent GoalReachedEvent;

    private bool hasThrownGoalEvent = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        hasThrownGoalEvent = false;

        // Add this tile for tracking through the LevelGrid
        LevelGrid.CurrLevelGrid.AddGoalTile(this.gameObject);
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // // Check if the player is in me.
        bool isPlayerInGoal = LevelGrid.CurrLevelGrid.Player.location == location;

        if (!hasThrownGoalEvent && isPlayerInGoal)
        {
            hasThrownGoalEvent = true;

            if (GoalReachedEvent != null)
                GoalReachedEvent.Raise();

            Debug.Log("Goooooooaaaaaallll.\n");
        }
    }


    public override bool CanGoThrough()
    {
        return true;
    }

    /// <summary>
    /// Reset this tile to its beginning state.
    /// </summary>
    public override void ResetTile()
    {
        base.ResetTile();
        
        hasThrownGoalEvent = false;
    }
}
