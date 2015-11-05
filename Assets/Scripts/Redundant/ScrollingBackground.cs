//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour 
{
	private float _speedY = -0.5f;
	private float _speedX = 0;
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
		_rigidBody.velocity = new Vector2 (_speedX, _speedY);
		
		//Destroys the object when it leaves the screen
		if(transform.position.y < _minScreenHeight / 64 - 20)
		{
			Debug.Log(transform.position);
			Vector2 newPosition = new Vector2 (0,32);
			transform.position = newPosition;
		}

	}

}

