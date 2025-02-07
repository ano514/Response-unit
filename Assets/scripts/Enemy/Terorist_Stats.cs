using UnityEngine;

public class Terorist_Stats : CharacterStats
{
    
    void Start()
    {
        InitVariables(health, shield);  
    }
    private void Update()
    {
        if (isDead)
        {
            PointSystem.EnemyKilledAddPoint(1);
            Destroy(gameObject);

        }
    }
}
