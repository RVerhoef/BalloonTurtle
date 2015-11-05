//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class Sink : MonoBehaviour 
{
	private float _speed = - 1;
	private float _minScreenHeight;
	private Rigidbody2D _rigidBody;

	void Start () 
	{
		_minScreenHeight = Screen.height - Screen.height * 2;
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		//Makes the object move downwards
		_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, _speed);
		
		//Destroys the object when it leaves the screen
		if(transform.position.y < _minScreenHeight / 64 * 2)
		{
			Destroy(gameObject);
		}

	}

}
