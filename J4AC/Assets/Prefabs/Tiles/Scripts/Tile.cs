﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Tooltip("The location of this tile on the grid in LevelGrid.")]
    public Vector2Int location;

    [Tooltip("The length of a single grid unit, i.e. 1.0f = 1 grid unit. Use this when relative positioning.")]
    public float SizePerUnit = 1.0f;

    // Keep track of original position, especially if this is a moving tile, ie Player.
    private Vector2Int origLocation;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        origLocation = location;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    private void OnValidate()
    {
        SnapToTile();
    }


    /// <summary>
    /// Reset this tile to its beginning state.
    /// </summary>
    public virtual void ResetTile()
    {
        location = origLocation;
        SnapToTile();
    }


    /// <summary>
    /// Whether or not another tile can go on top of this tile. 
    /// </summary>
    /// <returns></returns>
    public virtual bool CanGoThrough()
    {
        return true;
    }


    /// <summary>
    /// Snaps this tile (relative to a parent object) to it's current grid location.
    /// </summary>
    public void SnapToTile()
    {
        // Snap tiles relative to parent object containing all grid elements.
        if (LevelGrid.CurrLevelGrid != null)
            SizePerUnit = LevelGrid.CurrLevelGrid.SizePerUnit;

        this.transform.localPosition = new Vector3(location.x * SizePerUnit, location.y * SizePerUnit, transform.position.z);
    }

    /// <summary>
    /// Snaps this tile (relative to a parent object) to a specified grid location.
    ///   Will also set the location member variable.
    /// </summary>
    public void SnapToTile(Vector2Int position)
    {
        location = position;

        SnapToTile();
    }


}
