using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioButtons : MonoBehaviour
{
    public GameObject boomBox;
    public GameObject musicBox;

    public bool muted = false;
    public bool mutedMusic = false;

    public Sprite soundOn;
    public Sprite soundOff;
    public Button soundButton;

    public Sprite musicOn;
    public Sprite musicOff;
    public Button musicButton;

    void Awake()
    {
        boomBox = GameObject.FindGameObjectWithTag("BOOM");

        musicBox = GameObject.FindGameObjectWithTag("Music");
    }

    public void SFXButton()
    {
        muted = !muted;
        if (muted)
        {
            soundButton.image.sprite = soundOff;
        }
        else
        {
            soundButton.image.sprite = soundOn;
        }
    }

    public void MusicButton()
    {
        mutedMusic = !mutedMusic;
        if (mutedMusic)
        {
            musicButton.image.sprite = musicOff;
            musicBox.GetComponent<AudioSource>().Pause();
        }
        else
        {
            musicButton.image.sprite = musicOn;
            musicBox.GetComponent<AudioSource>().Play();
        }
    }

    public void MoveSound()
    {
        boomBox.GetComponent<DontDestroyOnLoad>().SoundFX(2);
    }

    public void HealSound()
    {
        boomBox.GetComponent<DontDestroyOnLoad>().SoundFX(3);
    }

    public void AttackSound()
    {
        boomBox.GetComponent<DontDestroyOnLoad>().SoundFX(1);
    }
}
