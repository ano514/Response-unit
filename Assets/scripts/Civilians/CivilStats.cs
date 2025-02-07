using UnityEngine;

public class CivilStats : CharacterStats
{
    void Start()
    {
        InitVariables(health, shield);
    }
    public void Update()
    {
        if (isDead)
        {
            PointSystem.CivilianKilledAddPoint(1);
            Destroy(gameObject);
        }
    }

    
}
