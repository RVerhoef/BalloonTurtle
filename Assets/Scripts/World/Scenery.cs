//Written by Rob Verhoef
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Scenery : MonoBehaviour 
{
	private float _speed = -1;
	private Rigidbody2D _rigidBody;
	
	void Awake () 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
	{
		//Makes the scenery move downwards
		_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, _speed);
	}
}
