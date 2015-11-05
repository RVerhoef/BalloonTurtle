//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class Cleaner : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D collider)
    {
        //Gameobjects are destroyed when they reach the cleaner
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Scenery" || collider.gameObject.tag == "Pickup")
        {
            Destroy(collider.gameObject);
        }
    }
}
