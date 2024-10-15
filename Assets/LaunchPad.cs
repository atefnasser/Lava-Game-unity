using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float launchForce = 10f;  // You can adjust this to control how high the player is launched

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Apply an upward force to the player when they touch the geyser or volcano
                playerRb.velocity = new Vector2(playerRb.velocity.x, launchForce);
            }
        }
    }
}
