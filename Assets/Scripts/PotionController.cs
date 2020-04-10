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
