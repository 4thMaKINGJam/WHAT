using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClipButton;
    public AudioClip audioClipClear;
    public AudioClip audioClipCorrect;
    public AudioClip audioClipInCorrect;
    public AudioClip audioClipTyping;

    public static SoundManager instance;

    void Awake()
    {
        if (SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }

        else
        {
            if (instance != this) //중복으로 존재할시에는 파괴! 
                Destroy(this.gameObject);
        }
    }


    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(audioClipButton);
    }
    public void PlayClearSound()
    {
        audioSource.PlayOneShot(audioClipClear);
    }
    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(audioClipCorrect);
    }
    public void PlayIncorrectSound()
    {
        audioSource.PlayOneShot(audioClipInCorrect);
    }
    public void PlayTypingSound()
    {
        audioSource.PlayOneShot(audioClipTyping);
    }

}
