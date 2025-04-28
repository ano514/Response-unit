using UnityEngine;

public class CivilStats : CharacterStats
{
    [SerializeField] private AudioSource a;
    [SerializeField] private AudioClip[] veza;
    void Start()
    {
        InitVariables(health, shield);
    }
    public void Update()
    {
        if (isDead)
        {
            PointSystem.CivilianKilledAddPoint(1);
            a.clip = veza[Random.Range(0, veza.Length)];
            a.Play();
            Destroy(gameObject);
        }
    }

    
}
