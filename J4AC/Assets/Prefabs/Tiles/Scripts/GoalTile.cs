using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTile : Tile
{
    private bool hasThrownGoalEvent = false;

    // Start is called before the first frame update
    void Start()
    {
        hasThrownGoalEvent = false;

        // Add this tile for tracking through the LevelGrid
        LevelGrid.CurrLevelGrid.AddGoalTile(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        // // Check if the player is in me.
        bool isPlayerInGoal = LevelGrid.CurrLevelGrid.Player.location == location;

        if (!hasThrownGoalEvent && isPlayerInGoal)
        {
            // @todo 
            hasThrownGoalEvent = true;

            Debug.Log("Goooooooaaaaaallll.\n");
        }
    }


    public override bool CanGoThrough()
    {
        return true;
    }
}
