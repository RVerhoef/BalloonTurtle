//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private float _movementSpeed = 10;
    private float _jumpSpeed = 4;
    private float _floatingSpeed = -2;
    private float _direction = 1;
    private float _maxJumpHeight = 0.0f;
    private float _minJumpHeight = -6.5f;
    private bool _gameOver;
    private bool _jumping;
    private bool _falling;
	private Rigidbody2D _rigidBody;
    private Animator _animator;
    private GameManager _gameManager;

    void Awake () 
	{
		_rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

	void FixedUpdate () 
	{
		//Flip sprite when moving
		if(Input.GetAxis ("Horizontal") > 0 && _jumping == false)
		{
			_direction = -1;
		}
		else if(Input.GetAxis ("Horizontal") < 0 && _jumping == false)
		{
			_direction = 1;
		}
		transform.localScale = new Vector2(_direction ,transform.localScale.y);
		//Allows player to move from side to side
		if (Input.GetAxis ("Horizontal") < 0 && _gameOver == false && _jumping == false) 
		{
			_rigidBody.velocity = new Vector2 ((Input.GetAxis ("Horizontal") * (_movementSpeed)), _rigidBody.velocity.y);
            _animator.SetBool("Moving", true);
		}
		else if (Input.GetAxis ("Horizontal") > 0 && _gameOver == false && _jumping == false)
		{
			_rigidBody.velocity = new Vector2 ((Input.GetAxis ("Horizontal") * (_movementSpeed)), _rigidBody.velocity.y);
            _animator.SetBool("Moving", true);
        }
		else if (_gameOver == false && _jumping == false)
		{
			_rigidBody.velocity = new Vector2 (0, _rigidBody.velocity.y);
            _animator.SetBool("Moving", false);
        }
        //The player jumps up and floats back down again
        if (Input.GetKeyDown("space") && _gameManager.Pickups > 0 && _gameOver == false && _jumping == false)
        {
            _gameManager.DecreaseScore();
            _jumping = true;
        }
        else if (transform.position.y <= _maxJumpHeight && _jumping == true && _falling == false)
        {
            _animator.SetBool("Jumping", true);
            _rigidBody.velocity = new Vector2(0, _jumpSpeed);
        }
        else if (transform.position.y >= _maxJumpHeight && _falling == false)
        {
            _animator.SetBool("Jumping", false);
            _animator.SetBool("Falling", true);
            _jumping = false;
            _falling = true;
        }
        else if (_falling == true && transform.position.y > _minJumpHeight)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _floatingSpeed);
        }
        else
        {
            _animator.SetBool("Falling", false);
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _falling = false;
        }
    }

	public void GameOver ()
	{
        //Player plays death animation and falls 
        _gameOver = true;
        _animator.SetBool("Dead", true);
        _rigidBody.gravityScale = 20.0f;
        _rigidBody.velocity = new Vector2(0, _rigidBody.velocity.y);
    }
}
