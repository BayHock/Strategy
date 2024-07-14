using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer mixerMus;
    [SerializeField] private AudioMixer mixerSou;
    [Header("Audio Slider")]
    [SerializeField] private Slider sliderMus;
    [SerializeField] private Slider sliderSou;

    private void Start()
    {
        sliderMus.value = PlayerPrefs.GetFloat("MusicVol", 0.75f);
        sliderSou.value = PlayerPrefs.GetFloat("SoundVol", 0.3f);
    }

    public void SetLevelMusic (float sliderValue)
    {
        mixerMus.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }
    public void SetLevelSound(float sliderValue)
    {
        mixerSou.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SoundVol", sliderValue);
    }
}
