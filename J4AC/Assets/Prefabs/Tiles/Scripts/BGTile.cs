using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTile : Tile
{
    
    public bool IsObstacle = false;

    public bool IsHidden = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Vector3 localScale = Vector3.zero;
        if (IsHidden)
        {
            // Hide me and me children
            localScale = Vector3.zero;
        }
        else
        {
            localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        transform.localScale = localScale;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Start();
    }

    private void OnValidate()
    {
        Vector3 localScale = Vector3.zero;
        if (IsHidden)
        {
            // Hide me and me children
            localScale = Vector3.zero;
        }
        else
        {
            localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        transform.localScale = localScale;
    }

    public override bool CanGoThrough()
    {
        return !IsObstacle && !IsHidden;
    }
}
