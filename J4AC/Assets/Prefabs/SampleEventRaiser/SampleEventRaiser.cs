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
            MoveLeft.Raise();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight.Raise();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp.Raise();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown.Raise();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoorToggle.Raise();
        }
    }
}
