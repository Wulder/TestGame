using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : CustomButton
{
    protected override bool IsPressed()
    {
        return !AudioManager.Instance.IsSoundsOn;

    }

    protected override void OnIsPressed()
    {
        var image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.b, image.color.b, .5f);

    }

    protected override void OnIsUnpressed()
    {
        var image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.b, image.color.b, 1);
    }

    protected override void OnClick()
    {
        if (AudioManager.Instance.IsSoundsOn)
        {
            AudioManager.Instance.TurnOffSounds();
            OnIsPressed();
        }
        else
        {
            AudioManager.Instance.TurnOnSounds();
            OnIsUnpressed();
        }

    }
}
