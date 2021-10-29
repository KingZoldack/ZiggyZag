using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _clickSound;
    [SerializeField] AudioClip _collectSound;
    [SerializeField] [Range(0, 1)] float _clickSoundVolume;
    [SerializeField] [Range(0, 1)] float _collectSoundVolume;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        //Singleton applied below so music does not restart when changing scenes.
        int numAudioManagers = FindObjectsOfType<AudioManager>().Length;

        if (numAudioManagers > 1)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    
    public void PlayClickSound()
    {
        _audioSource.PlayOneShot(_clickSound, _collectSoundVolume);
    }

    public void PlayCollectionSound()
    {
        _audioSource.PlayOneShot(_collectSound, _collectSoundVolume);
    }
}
