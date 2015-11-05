//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour 
{
    private float _speed = 5;
    private float _randomShootTime;
    private bool _fired;
    private Transform _laser;
    private Rigidbody2D _rigidBody;

    void Awake () 
	{
        _rigidBody = GetComponent<Rigidbody2D>();
        _randomShootTime = Random.Range(5,25);
        _laser = transform.FindChild("Laser");
    }

	void FixedUpdate () 
	{
        //The cannon moves downward until it reaches the upper edge of the screen, after which it stops moving and fires its laser after a randomly determined amount of time
        if (transform.position.y > Screen.height / 64 && _fired == false)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, -_speed);
        }
        else if (transform.position.y <= Screen.height / 64 && _fired == false)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            Invoke ("Shoot", _randomShootTime);
        }
	}

    void Shoot ()
    {
        //The laser is shot
        _laser.gameObject.SetActive(true);
        _fired = true;
        Invoke("HasShot", 5);
    }

    void HasShot ()
    {
        //The laser disapears
        _laser.gameObject.SetActive(false);
        Invoke("Retreat", 10);
    }

    void Retreat ()
    {
        //The cannon moves up again
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _speed);
    }
}
