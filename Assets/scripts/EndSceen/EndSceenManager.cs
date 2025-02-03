using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceenManager : MonoBehaviour
{
    public void LoadSceen(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadSceenLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
