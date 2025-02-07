using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private GameObject[] Enemy;
    private GameObject[] Civilian;
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        Civilian = GameObject.FindGameObjectsWithTag("Civil");
    }

    void Update()
    {
        if (PointSystem.civilianarrest+PointSystem.civiliankilled == Civilian.Length && PointSystem.enemyarrest + PointSystem.enemykilled == Enemy.Length)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
