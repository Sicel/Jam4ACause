using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEventRaiser : MonoBehaviour
{
    /*
     * This script is purely for unit testing the event listeners. 
     */ 


    public GameEvent MoveLeft;

    public GameEvent MoveRight;

    public GameEvent MoveUp;

    public GameEvent MoveDown;

    public GameEvent DoorOpen;

    public GameEvent DoorClose;

    public GameEvent DoorToggle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (MoveLeft != null)
                MoveLeft.Raise();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (MoveRight != null)
                MoveRight.Raise();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (MoveUp != null)
                MoveUp.Raise();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (MoveDown != null)
                MoveDown.Raise();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DoorToggle != null)
                DoorToggle.Raise();
        }
    }
}
