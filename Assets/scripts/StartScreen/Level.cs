using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public GameObject levelScreen;
    public GameObject startScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("1level2floor");
    }
    public void GoBack()
    {
        levelScreen.SetActive(false);
        startScreen.SetActive(true);
    }
    public void GoLevel()
    {
        levelScreen.SetActive(true);
        startScreen.SetActive(false);
    }
}
