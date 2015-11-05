//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour 
{
	private float _downwardSpeed = -3;
    private float _sidewardSpeed = -5;
	private Rigidbody2D _rigidBody;
    private bool _goingLeft;
    private bool _goingRight;

	void Awake () 
	{
        _rigidBody = GetComponent<Rigidbody2D>();
        //Decides if the obstacle moves left or right
        int i = Random.Range(1, 3);
        if(i == 1)
        {
            _goingLeft = true;
        }
        if(i == 2)
        {
            _goingRight = true;
        }
	}

	void FixedUpdate () 
	{
		//Makes the obstacle move downwards
		_rigidBody.velocity = new Vector2 (_rigidBody.velocity.x, _downwardSpeed);
        //Obstacle moves either right or left
        if(_goingLeft == true)
        {
            _rigidBody.velocity = new Vector2(_sidewardSpeed, _rigidBody.velocity.y);
        }
        if (_goingRight == true)
        {
            _rigidBody.velocity = new Vector2(-_sidewardSpeed, _rigidBody.velocity.y);
        }
    }
	void OnTriggerEnter2D (Collider2D collider)
	{
        //Triggers Gameover when player hits an obstacle
        if (collider.gameObject.tag == "Player") 
		{
			collider.GetComponent<PlayerMovement>().GameOver();
		}
        //Obstacle changes direction once the edge of the screen has been reached
        if (collider.gameObject.tag == "Border Left" && _goingLeft == true)
        {
            _goingRight = true;
            _goingLeft = false;
        }
        if (collider.gameObject.tag == "Border Right" && _goingRight == true)
        {
            _goingLeft = true;
            _goingRight = false;
        }
    }
}
