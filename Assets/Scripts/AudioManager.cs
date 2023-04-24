using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip cutSFX;
    [SerializeField, Range(0, 1)] float volume;

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
        AudioSource.PlayClipAtPoint(cutSFX, Camera.main.transform.position, volume);
    }
}
