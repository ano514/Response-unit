using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndSceenManager : MonoBehaviour
{
    public TMP_Text CivilArr;
    public TMP_Text CivilDead;
    public TMP_Text EnemArr;
    public TMP_Text EnemDead;
    private void Start()
    {
        string ca = CivilArr.text;
        ca = PointSystem.civilianarrest.ToString();
        string ce = CivilDead.text;
        ce = PointSystem.civiliankilled.ToString();
        string ea = EnemArr.text;
        ea = PointSystem.enemyarrest.ToString();
        string ee = EnemDead.text;
        ee = PointSystem.enemykilled.ToString();

    }
    public void LoadSceen(string scene) 
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadSceenLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
