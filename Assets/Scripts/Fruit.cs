
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject slicedFruitPrefab;

    float minExplosiveForce = 1000;
    float maxExplosiveForce = 2000;
    float explosionRadius = 10f;
    float timeToDestroy = 5f;

    AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();    
    }

    /// <summary>
    /// Creates the sliced fruit gameobject and add force to it 
    /// </summary>
    public void CreateSlicedFruit()
    {
        GameObject inst1 = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        GameObject inst2 = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);


        Rigidbody[] rbds1 = inst1.transform.GetComponentsInChildren<Rigidbody>();
        Rigidbody[] rbds2 = inst2.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbds1)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(minExplosiveForce, maxExplosiveForce), transform.position, explosionRadius);
        }

        foreach (Rigidbody rb in rbds2)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(minExplosiveForce, maxExplosiveForce), transform.position, explosionRadius);
        }
        Destroy(inst1.gameObject, timeToDestroy);
        Destroy(inst2.gameObject, timeToDestroy);
        Destroy(gameObject);
        
    }

    /// <summary>
    /// checks if knife collides with fruit
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        Blade blade = collision.GetComponent<Blade>();

        if(!blade)
        {
            return;
        }
        audioManager.PlayCutSFX();
        CreateSlicedFruit();
    }

    
    
}
