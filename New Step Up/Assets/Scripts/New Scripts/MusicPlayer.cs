using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 1);
        }
    }

    public void UpdateVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
