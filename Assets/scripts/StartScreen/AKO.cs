using UnityEngine;

public class AKO : MonoBehaviour
{
    public GameObject tutorialScreen;
    public GameObject startScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenTutorial()
    {
        tutorialScreen.SetActive(true);
        startScreen.SetActive(false);
    }
    public void CloseTutorial()
    {
        tutorialScreen.SetActive(false);
        startScreen.SetActive(true);
    }
}
