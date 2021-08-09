using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{
    public UnityEngine.UI.Slider volumeSlider;
    public void OnValueChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
