//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class HeliumPickup : MonoBehaviour 
{
	private float _speed = -2;
	private Rigidbody2D _rigidBody;
	private GameManager _gameManager;
	
	void Awake () 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_gameManager = GameObject.Find ("Game Manager").GetComponent<GameManager>();
	}
	
	void FixedUpdate () 
	{
        //Makes the pickup move downward
		_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, _speed);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
        //Makes the gamemanager update the score
		if (collider.gameObject.tag == "Player") 
		{
            _gameManager.IncreaseScore();
			Destroy (gameObject);
		}
	}
}
