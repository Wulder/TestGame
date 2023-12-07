using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : CustomButton
{
   

    
   
    protected override bool IsPressed()
    {
        return !AudioManager.Instance.IsMusicOn;
        
    }

    protected override void OnIsPressed()
    {
        var image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.b, image.color.b,.5f);
        
    }

    protected override void OnIsUnpressed()
    {
        var image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.b, image.color.b, 1);
    }

    protected override void OnClick()
    {
        if(AudioManager.Instance.IsMusicOn)
        {
            AudioManager.Instance.TurnOffMusic();
            OnIsPressed();
        }
        else
        {
            AudioManager.Instance.TurnOnMusic();
            OnIsUnpressed();
        }
            
    }

}
