using UnityEngine;
using System.Collections;

public class OrchidTree : MonoBehaviour
{
    [SerializeField] private Fruit[] _fruits;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _maxTimeToSpawn = 10;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    public IEnumerator SpawnFruits()
    {
        yield return new WaitForSeconds(Random.Range(1, _maxTimeToSpawn+1));

        Instantiate(_fruits[Random.Range(0, _fruits.Length)], _spawnPoint);

        StartCoroutine(SpawnFruits());
    }
}
