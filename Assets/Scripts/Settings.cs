using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider fovSlider;
    public Slider musicVolume;
    public AudioSource musicPlayer;
    public AudioSource audioSource;

    void Start()
    {
        fovSlider.minValue = 30;
        fovSlider.maxValue = 100;
        musicVolume.onValueChanged.AddListener(SetMusicListenerVolume);
    }

    private void SetMusicListenerVolume(float volume)
    {
        musicPlayer.volume = volume;
    }
    public void ApplyMusicSettings()
    {
        // The volume updates itself through the slider's events, so no need to update 
        // the volume in this function.
        //SetMusicListenerVolume();
    }

    public void ApplyEffectsSettings()
    {
        // Or this one.
        //SetEffectsListenerVolume();
    }

    public void SubmitButton()
    {
        audioSource.Play();
        Camera.main.fieldOfView = fovSlider.value;
    }
}
