//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Triggers Gameover when player hits an obstacle
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<PlayerMovement>().GameOver();
        }
    }
}
