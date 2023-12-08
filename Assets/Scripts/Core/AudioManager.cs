using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance => instance;

    private bool _isMusicOn, _isSoundsOn;

    public bool IsMusicOn => _isMusicOn;
    public bool IsSoundsOn => _isSoundsOn;

    [SerializeField] private AudioSource _musicSrc, _soundSrc;
    [SerializeField] private float _musicVolume, _soundsVolume;

    

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(this);

        Init();
    }
    
    
    void Init()
    {

        if (!PlayerPrefs.HasKey("music")) PlayerPrefs.SetInt("music",1);
        if (!PlayerPrefs.HasKey("sound")) PlayerPrefs.SetInt("sound",1);

        if (PlayerPrefs.GetInt("music") > 0)
            TurnOnMusic();
        else
            TurnOffMusic();

        if (PlayerPrefs.GetInt("sounds") > 0)
            TurnOnSounds();
        else
            TurnOffSounds();
    }

    public void TurnOffMusic()
    {
        _musicSrc.volume = 0;
        PlayerPrefs.SetInt("music", 0);
        _isMusicOn = false;
    }

    public void TurnOffSounds()
    {
        _soundSrc.volume = 0;
        PlayerPrefs.SetInt("sounds", 0);
        _isSoundsOn = false;
    }

    public void TurnOnMusic()
    {
        _musicSrc.volume = _musicVolume;
        PlayerPrefs.SetInt("music", 1);
        _isMusicOn = true;
    }

    public void TurnOnSounds()
    {
        _soundSrc.volume = _soundsVolume;
        PlayerPrefs.SetInt("sounds", 1);
        _isSoundsOn = true;
    }

    public void PlaySound(AudioClip clip)
    {
        _soundSrc.clip = clip;
        _soundSrc.Play();
    }
    
}
