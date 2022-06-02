using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getVolumeScript : MonoBehaviour
{

    [SerializeField]
    Slider b_Slider;
    [SerializeField]
    Slider s_Slider;

    void Start()
    { 
        b_Slider.value = AllManager.Instance.BgmVolume;
        s_Slider.value = AllManager.Instance.SeVolume;
    }


    public void BgmSoundSliderOnValueChange(float newSliderValue)
    {
        b_Slider.value = newSliderValue;
        AllManager.Instance.BgmVolume = newSliderValue;
        PlayerPrefs.SetFloat("BgmVolumePref", newSliderValue);
    }

    public void SeSoundSliderOnValueChange(float newSliderValue)
    {
        s_Slider.value = newSliderValue;
        AllManager.Instance.SeVolume = newSliderValue;
        PlayerPrefs.SetFloat("SeVolumePref", newSliderValue);
    }

    public void btn()
    {
        gameObject.SetActive(false);
    }

}
