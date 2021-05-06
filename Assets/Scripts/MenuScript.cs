using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Toggle MuteToggle;
    [SerializeField] private SoundManager SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("volume", 0.5f);
    }

    public void SliderMethod(float volume)
    {
        SoundManager.SliderMethod(volume);
        PlayerPrefs.SetFloat("volume", volume);
    }
}
