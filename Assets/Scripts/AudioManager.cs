using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Cut SFX")]
    [SerializeField] AudioClip cutSFX;
    [SerializeField, Range(0, 1)] float cutVolume = 0.5f;

    [Header("Bomb SFX")]
    [SerializeField] AudioClip bombSFX;
    [SerializeField, Range(0, 1)] float bombVolume = 0.5f;

    static AudioManager instance;

    void Awake()
    {
        // manages background music singleton
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

    /// <summary>
    /// Plays cuts SFX
    /// </summary>
    public void PlayCutSFX()
    {
        AudioSource.PlayClipAtPoint(cutSFX, Camera.main.transform.position, cutVolume);
    }

    /// <summary>
    /// Plays bomb hit SFX
    /// </summary>
    public void BombHitSFX()
    {
        AudioSource.PlayClipAtPoint(bombSFX, Camera.main.transform.position, bombVolume);
    }
}
