
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject slicedFruitPrefab;
    AudioManager audioManager;
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();    
    }

    public void CreateSlicedFruit()
    {
        GameObject inst1 = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        GameObject inst2 = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);


        Rigidbody[] rbds1 = inst1.transform.GetComponentsInChildren<Rigidbody>();
        Rigidbody[] rbds2 = inst2.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbds1)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }

        foreach (Rigidbody rb in rbds2)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }
        Destroy(inst1.gameObject, 5f);
        Destroy(inst2.gameObject, 5f);
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
