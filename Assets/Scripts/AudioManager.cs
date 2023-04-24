using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip cutSFX;
    [SerializeField, Range(0, 1)] float cutVolume = 0.5f;

    [SerializeField] AudioClip bombSFX;
    [SerializeField, Range(0, 1)] float bombVolume = 0.5f;

    static AudioManager instance;

    void Awake()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }        
    }

    public void PlayCutSFX()
    {
        AudioSource.PlayClipAtPoint(cutSFX, Camera.main.transform.position, cutVolume);
    }

    public void BombHitVFX()
    {
        AudioSource.PlayClipAtPoint(bombSFX, Camera.main.transform.position, bombVolume);
    }
}
