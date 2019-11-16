#define SELF_MOVE_DETECTION

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTile : Tile
{
    [Tooltip("How long does it take to move to a subsequent tile")]
    public float movementLerpTime = 0.3f;
    private float movementLerpTimer;

    [Range(0.0f, 1.0f)]
    public float invalidLerpNudgeRatio = 0.25f;

    // Keep track of start and end location of the lerp (separate from location)
    private Vector3 lerpSource;
    private Vector3 lerpDestination;

    // Which animation to play: move there or nudge against wall
    private bool isLerping;
    private bool isLerpingToInvalidTile;


    // Start is called before the first frame update
    void Start()
    {
        // Add this tile for tracking through the LevelGrid
        LevelGrid.CurrLevelGrid.AddTile(this.gameObject);

        // Initialize settings
        isLerping = false;
        isLerpingToInvalidTile = false;
        movementLerpTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

#if SELF_MOVE_DETECTION
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
#endif


        if (isLerping)
        {
            movementLerpTimer += Time.deltaTime;
           
            // If it's a valid movement (aka move 100% of the way)
            if (!isLerpingToInvalidTile)
            {
                Vector3 position = lerpSource + (movementLerpTimer / movementLerpTime) * (lerpDestination - lerpSource);
                transform.localPosition = position;
            }
            // Otherwise (nudge against it)s
            else
            {
                Vector3 position = Vector3.zero;

                if (movementLerpTimer < invalidLerpNudgeRatio * movementLerpTime)
                {
                    // First quarter of the time, move out to a quarter-ish
                    position = lerpSource + (movementLerpTimer / movementLerpTime) * (lerpDestination - lerpSource);
                }
                else
                {
                    // Remainder of the time, move back
                        // position = stating location + percentage moved * displacement
                    position = (lerpSource + invalidLerpNudgeRatio * (lerpDestination - lerpSource)) 
                        + ( (movementLerpTimer - invalidLerpNudgeRatio * movementLerpTime) / ( (1.0f - invalidLerpNudgeRatio) * movementLerpTime)) 
                        * (lerpSource - (lerpSource + invalidLerpNudgeRatio * (lerpDestination - lerpSource)));
                }


                transform.localPosition = position;
            }

            if (movementLerpTimer > movementLerpTime)
            {
                SnapToTile();
                isLerping = false;
            }
        }
    }

    public override bool CanGoThrough()
    {
        return false;
    }

    
    private void TryToMoveTo(Vector2Int des)
    {
        // Check if we can go there
        bool isDesValid = LevelGrid.CurrLevelGrid.CanGoThroughTile(des);

        // Set the lerping flags on
        isLerping = true;
        isLerpingToInvalidTile = !isDesValid;
        movementLerpTimer = 0f;

        // Set the lerp source and destination
        lerpSource = new Vector3(location.x, location.y);  // Current location
        lerpDestination = new Vector3(des.x, des.y);  // Destination to try to lerp to (or get sent back)

        // If this is valid, set location to be that location.
        if (isDesValid)
            location = des;
    }


    #region EVENT HANDLERS

    /// <summary>
    /// 
    /// </summary>
    public void MoveLeft()
    {
        Vector2Int des = location;
        des.x = location.x - 1;

        TryToMoveTo(des);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveRight()
    {
        Vector2Int des = location;
        des.x = location.x + 1;

        TryToMoveTo(des);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveUp()
    {
        Vector2Int des = location;
        des.y = location.y + 1;

        TryToMoveTo(des);
    }

    /// <summary>
    /// 
    /// </summary>
    public void MoveDown()
    {
        Vector2Int des = location;
        des.y = location.y - 1;

        TryToMoveTo(des);
    }

    #endregion
}
