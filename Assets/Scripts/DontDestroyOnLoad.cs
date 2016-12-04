using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject child;

    public AudioClip cannon;
    public AudioClip confirmation;
    public AudioClip heal;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SoundFX(int effect)
    {
        AudioSource sfx = GetComponent<AudioSource>();
        if (effect == 1)
        {
            sfx.clip = cannon;
            sfx.Play();
        }
        else if (effect == 2)
        {
            sfx.clip = confirmation;
            sfx.Play();
        }
        else if (effect == 3)
        {
            sfx.clip = heal;
            sfx.Play();
        }

    }
}