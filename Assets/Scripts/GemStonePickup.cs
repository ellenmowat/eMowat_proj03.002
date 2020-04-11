using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStonePickup : MonoBehaviour
{
    public AudioClip pickupClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy the gemstone when it collides with the player
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        }
    }
}
