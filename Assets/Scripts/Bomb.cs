using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //blade class will be called if the collision is with blade i.e. mouse
        Blade b = collision.GetComponent<Blade>();

        if(!b)
        {
            return;
        }

        audioManager.BombHitSFX();
        FindObjectOfType<GameManager>().BombHit();
    }
}
