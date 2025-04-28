using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class EndSceenManager : MonoBehaviour
{
    public TMP_Text CivilArr;
    public TMP_Text CivilDead;
    public TMP_Text EnemArr;
    public TMP_Text EnemDead;
    public TMP_Text Answer;
    private void Start()
    {
        Cursor.visible = true;
        CivilArr.text = PointSystem.civilianarrest.ToString();
        CivilDead.text = PointSystem.civiliankilled.ToString();
        EnemArr.text = PointSystem.enemyarrest.ToString();
        EnemDead.text = PointSystem.enemykilled.ToString();
        if (PointSystem.civilianarrest == 25 && PointSystem.civilianarrest>5) 
        { 

            Answer.text = "A";
        }
        else if (PointSystem.civilianarrest == 25 && PointSystem.civilianarrest == 18)
        {

            Answer.text = "S";
        }
        else if (PointSystem.civilianarrest >=20)
        {

            Answer.text = "C";
        }
        else if (PointSystem.civilianarrest >= 10)
        {
            
            Answer.text = "D";
        }
        else if(PointSystem.civilianarrest == 0 && PointSystem.civilianarrest==0 && PointSystem.civiliankilled==0 && PointSystem.enemykilled==0)
        {

            Answer.text = "S";
        }
        else
        {

            Answer.text = "F";
        }


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
