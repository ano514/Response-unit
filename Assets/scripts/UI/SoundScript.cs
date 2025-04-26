using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
   

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Slider slider3;
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;
    void Start()
    {
        SetGenral();
        SetSFX();
        SetTalking();
    }

    
    void Update()
    {
        
    }

    public void SetGenral()
    {
        float volume= slider1.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        text1.text = ((int)(volume*100)).ToString();
    }
    public void SetSFX(){
        float volume = slider2.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        text2.text = ((int)(volume * 100)).ToString();
    }

    public void SetTalking()
    {
        float volume = slider3.value;
        audioMixer.SetFloat("Talking", Mathf.Log10(volume)*20);
        text3.text = ((int)(volume * 100)).ToString();
    }
}
