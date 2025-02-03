using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject optionScreen;
    public GameObject startScreen;
    public Toggle fullscreenTog;
    public Toggle vsyncTog;
    
    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }
        
    }

    
    void Update()
    {
        
    }

    public void OpenOptions()
    {
        optionScreen.SetActive(true);
        startScreen.SetActive(false);
    }
    public void CloseOptions()
    {
        optionScreen.SetActive(false);
        startScreen.SetActive(true);
    }
    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTog.isOn;
        Debug.Log(Screen.fullScreen);
        if (vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
            Debug.Log(QualitySettings.vSyncCount);
        }
        else
        {
            Debug.Log(QualitySettings.vSyncCount);
            QualitySettings.vSyncCount = 0;
        }
    }
}
