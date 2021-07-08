using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;

    public Slider volumeSlider;

    // Value from the slider, and it converts to volume level
    public float musicVolume = 1f;


    private void Start()
    {
        AudioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    private void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume" , musicVolume);
    }

    public void updateVolume (float volume)
    {
        musicVolume = volume;
    }
}
