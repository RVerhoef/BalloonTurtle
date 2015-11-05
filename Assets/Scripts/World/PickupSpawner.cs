//Written by Rob Verhoef
using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour 
{
    [SerializeField] private Transform _pickup;
    private float _randomSpawntime;
    private bool _spawning;

    void Update ()
    {
        //Spawns a pickup after a randomly determined amount of time
        if (_spawning == false && _randomSpawntime == 0)
        {
            Invoke("Spawn", 50);
            _spawning = true;
        }
        else if (_randomSpawntime > 0)
        {
            _randomSpawntime--;
        }
    }

    void Spawn ()
    {
        //The pickup is spawned
        Instantiate(_pickup, new Vector2(Random.Range(-13, 13), transform.position.y), transform.rotation);
        _randomSpawntime = Random.Range(101, 251);
        _spawning = false;
    }
}

