using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    //enum PotionType will be a new data type
    public enum PotionType
    {
        Speed,
        Jump
    }

    //enum data type PotionType will be assigned to a new variable called potionType
    public PotionType potionType;
    public int potionModAmount = 0;

    //make the potion look like it's floating

    //record how long it's been floating
    private float floatingTimer = 0f;
    //determine how long we want it to float
    private float floatingMax = 1f;
    //up is pos, down is neg
    private float floatingDir = 0.01f;
    
    private void FixedUpdate()
    {
        if (floatingTimer < floatingMax)
        {
            //change the position of our current object
            //x doesn't change, y increments by floatingDir
            transform.position = new Vector2(transform.position.x, transform.position.y + floatingDir);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //collided with the player
            if (potionType == PotionType.Jump)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasJumpPotion = true;
            }
            else if (potionType == PotionType.Speed)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasSpeedPotion = true;
            }

            //set this potionModAmount equal to the same variable in the PlayerMovement script
            collision.gameObject.GetComponent<PlayerMovement>().potionModAmount = potionModAmount;

            //destroy the potion
            Destroy(this.gameObject);

        }
    }
}
