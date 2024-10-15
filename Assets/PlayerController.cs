using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Vector3 respawnPoint;  // Set the respawn point in Unity
    public float deathDelay = 1f; // Delay before respawning

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;  // Set the initial position as the respawn point
    }

    void Update()
    {
        // You can add movement code here, such as for jumping or walking

        // Example movement code (optional):
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * 5f, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);  // Basic jump mechanic
        }
    }

    public void Die()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        // Optionally disable player controls or add death animation here
        yield return new WaitForSeconds(deathDelay);
        transform.position = respawnPoint;  // Move the player back to the respawn point
        // Optionally re-enable player controls here
    }
}
