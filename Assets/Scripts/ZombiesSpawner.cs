using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ZombieReference;

    private GameObject spawnedZombie;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombies());   
    }

    IEnumerator SpawnZombies()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));

        randomIndex = Random.Range(0, ZombieReference.Length);
        randomSide = Random.Range(0, 2);
        
        spawnedZombie = Instantiate(ZombieReference[randomIndex]);

    }
}
