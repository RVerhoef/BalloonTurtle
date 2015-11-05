//Written by Rob Verhoef
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random; 

public class ScenerySpawner : MonoBehaviour 
{
	[SerializeField] private Transform _scenery1;
	[SerializeField] private Transform _scenery2;
	[SerializeField] private Transform _scenery3;
	private Transform _chosenScenery;
	private float _randomScenery;
	private float _randomPosition;
    private float _randomSpawntime;
    private bool _spawnRight;
    private bool _spawnLeft;
    private bool _spawning;
	
	void Awake () 
	{
        _spawnLeft = true;
    }
	
    void Update ()
    {
        //Spawns a piece of scenery after a randomly determined amount of time
        if (_spawning == false && _randomSpawntime == 0)
        {
            Invoke("Spawn", 5);
            _spawning = true;
        }
        else if (_randomSpawntime > 0)
        {
            _randomSpawntime--;
        }
    }

	void Spawn ()
	{
        //A random piece of scenery is chosen
		_randomScenery = Random.Range (1, 4);
		if (_randomScenery == 1)
        {
		    _chosenScenery = _scenery1;
        }
        else if (_randomScenery == 2)
        {
		    _chosenScenery = _scenery2;
		}
        else if (_randomScenery == 3)
        {
		    _chosenScenery = _scenery3;
		}
		//Makes sure the scenery doesnt spawn too close to eachother
        if (_spawnLeft == true)
        {
            _randomPosition = Random.Range(-2, -14);
            _spawnRight = true;
            _spawnLeft = false;
        }
        else if (_spawnRight == true)
        {
            _randomPosition = Random.Range(2, 14);
            _spawnLeft = true;
            _spawnRight = false;
        }
        //The chosen enemy is spawned
	    Instantiate (_chosenScenery, new Vector2 (_randomPosition, transform.position.y), transform.rotation);
        _randomSpawntime = Random.Range(21, 51);
        _spawning = false;
	}
}
