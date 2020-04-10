using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjects : MonoBehaviour
{
    //make the potion look like it's floating

    //record how long it's been floating
    private float floatingTimer = 0f;
    //determine how long we want it to float
    public float floatingMax = 1f;
    //up is pos, down is neg
    public float floatingDir = 0.01f;

    private void FixedUpdate()
    {
        if (floatingTimer < floatingMax)
        {
            //change the position of our current object
            //x doesn't change, y increments by floatingDir
            transform.position = new Vector2(transform.position.x, 
                transform.position.y + (Time.fixedDeltaTime * floatingDir));
            //add seconds to the timer every fixed update
            floatingTimer += Time.fixedDeltaTime;
        }
        else
        {
            //change direction
            floatingDir *= -1;
            floatingTimer = 0;
        }
    }
}
