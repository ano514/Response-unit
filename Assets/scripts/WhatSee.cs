using UnityEngine;

public class WhatSee : MonoBehaviour
{
    public Transform Head;
    private Terorist Terorist;
    private Enemy Enemy;
    private Surrender sur;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        WhatIsSee();
    }
    private void WhatIsSee()
    {
        RaycastHit hit;
        if (Physics.Raycast(Head.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Civil")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Random.Range(1, 100) < 10)
                    {
                        sur = hit.collider.GetComponent<Surrender>();
                        sur.Surender();
                    }
                }
            }
            else if (hit.collider.tag == "Enemy")
            {
                Enemy = hit.collider.GetComponent<Enemy>();
                Terorist = hit.collider.GetComponent<Terorist>();
                if (!Enemy.CanSeePlayer())
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (Random.Range(1, 100) < 10)
                        {
                            Terorist.Surender();
                        }
                        else
                        {
                            Enemy.fieldOfView = 180f;
                            Enemy.sightDistance += 20f;
                        }
                    }
                }
            }
            if (Physics.Raycast(Head.position, transform.forward, out hit, 1f))
            {
                if (hit.collider.tag == "Civil")
                {
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        sur = hit.collider.GetComponent<Surrender>();
                        sur.Arest();
                    }
                }
                if (hit.collider.tag == "Enemy")
                {
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        Terorist = hit.collider.GetComponent<Terorist>();
                        Terorist.Arrest();
                    }
                }
            }
        }
    }
}
