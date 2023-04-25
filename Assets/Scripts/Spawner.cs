using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Interactables")]
    [SerializeField] GameObject[] fruitsToSpawn;
    [SerializeField] GameObject bomb;

    [Header("Coroutine Related Values")]
    [SerializeField] float minWaitTime, maxWaitTime;

    [Header("Force Related Values")]
    [SerializeField] float minForce, maxForce;

    [Header("Spawn Places")]
    [SerializeField] Transform[] spawnPlaces;

    float waitTimeBeforeDestroying = 5f;
    void Start()
    {
        StartCoroutine(FruitSpawner());
    }

    /// <summary>
    /// Spawns a random fruit from an array of fruits in a random place
    /// </summary>
    /// <returns></returns>
    IEnumerator FruitSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            GameObject gameObjectToSpawn;

            int chance = Random.Range(1, 100);

            if (chance < 25)
            {
                gameObjectToSpawn = bomb;
            }
            else
            {
                gameObjectToSpawn = fruitsToSpawn[Random.Range(0, fruitsToSpawn.Length)];
            }
            Transform place = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject fruit = Instantiate(gameObjectToSpawn, place.position, place.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(place.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Destroy(fruit, waitTimeBeforeDestroying);
        }
         
    }
}
