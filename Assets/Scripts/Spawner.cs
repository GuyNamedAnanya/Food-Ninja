using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] fruitsToSpawn;
    [SerializeField] GameObject bomb;
    GameObject fruit;
    GameObject gameObjectToSpawn;
    
    

    [SerializeField] Transform[] spawnPlaces;
    Transform place;

    [SerializeField] float minTime, maxTime;
    [SerializeField] float minForce, maxForce;

    int chance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FruitSpawner());
    }

    IEnumerator FruitSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            chance = Random.Range(1, 100);

            if (chance < 25)
            {
                gameObjectToSpawn = bomb;
            }
            else
            {
                gameObjectToSpawn = fruitsToSpawn[Random.Range(0, fruitsToSpawn.Length)];
            }
            place = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            fruit = Instantiate(gameObjectToSpawn, place.position, place.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(place.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);

            Destroy(fruit, 5f);
        }
        

        
    }
}
