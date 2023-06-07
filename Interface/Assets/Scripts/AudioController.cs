using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    [SerializeField] List<AudioClip> musics;

    [SerializeField] Slider soundVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;

    private void Start()
    {
        RefreshSliders(AudioManager.soundVolume, AudioManager.musicVolume);

        StartCoroutine(PlayRandomMusic());
    }

    public void ChangeSoundVolume(float volume)
    {
        AudioManager.soundVolume = volume;
        AudioListener.volume = AudioManager.soundVolume;

        RefreshSliders(AudioManager.soundVolume, AudioManager.musicVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        AudioManager.musicVolume = volume;
        musicSource.volume = AudioManager.musicVolume;

        RefreshSliders(AudioManager.soundVolume, AudioManager.musicVolume);
    }

    IEnumerator PlayRandomMusic()
    {
        while (musicSource.isPlaying) yield return null;

        int currentIndex = Random.Range(0, musics.Count);

        musicSource.clip = musics[currentIndex];
        musicSource.Play();

        yield break;
    }

    public void RefreshSliders(float soundVolume, float musicVolume)
    {
        soundVolumeSlider.value = soundVolume;
        musicVolumeSlider.value = musicVolume;
    }
}
