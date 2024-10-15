using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMonster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // When the player touches the monster, they die and respawn
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();  // Assuming you have a Die() method in the PlayerController script
            }
        }
    }
}
