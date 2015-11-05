//Written by Rob Verhoef
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random; 

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] private Object[] _enemies;
    private Object _chosenEnemy;
    private float _randomSpawntime;
    private bool _spawning;

    void Awake ()
    {
        _enemies = Resources.LoadAll("Prefabs/Enemy/Formations", typeof (Object));
    }

    void Update()
    {
        //Spawns an enemy after a randomly determined amount of time, or reduces the spawning timer
        if (_spawning == false && _randomSpawntime == 0)
        {
            Invoke("Spawn", 25);
            _spawning = true;
        }
        else if (_randomSpawntime > 0)
        {
            _randomSpawntime--;
        }
    }

    void Spawn ()
    {
        //A random enemy is chosen & spawned
        _chosenEnemy = _enemies[Random.Range(0, _enemies.Length)];
        Instantiate(_chosenEnemy, new Vector2(Random.Range(-11, 11), transform.position.y), transform.rotation);
        _randomSpawntime = Random.Range(15, 101);
        _spawning = false;
    }
}
