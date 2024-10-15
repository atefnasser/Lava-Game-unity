using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scenes


public class DieAndRestart : MonoBehaviour
{

    public int Respawn; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) // other means it will act on another object, not this one.   It loads the respawn scene if it hits the player.
    {
        if (other.CompareTag("Player")) // Anything with the player tag, which we gave to player.
        { 
            SceneManager.LoadScene(Respawn);
        }
        
    }

}
