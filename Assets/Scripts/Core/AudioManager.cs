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

    [SerializeField] private AudioSource _musicSrc;
    [SerializeField] private float _musicVolume;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(this);

        Init();
    }
    

    void Init()
    {
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
        PlayerPrefs.SetInt("sounds", 1);
        _isSoundsOn = true;
    }
    
}
