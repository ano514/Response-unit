using UnityEngine;
using static Unity.VisualScripting.Member;

public class WhatSee : MonoBehaviour
{
    public Transform Head;
    private Terorist Terorist;
    private Enemy Enemy;
    private Surrender sur;
    [SerializeField] private AudioClip[] civilian;
    [SerializeField] private AudioClip[] suspect;
    [SerializeField] private AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        WhatIsSee();
        Preferences();
    }

    private void Preferences()
    {
        audio = GetComponent<AudioSource>();
    }
    private void WhatIsSee()
    {
        RaycastHit hit;
        if (Physics.Raycast(Head.position, transform.forward, out hit))
        {
            if (hit.collider.tag == "Civil")
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (!audio.isPlaying)
                    {
                        audio.clip = civilian[Random.Range(0, civilian.Length - 1)];
                        audio.Play();
                    }
                    if (Random.Range(1, 100) > 10)
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
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        if (!audio.isPlaying)
                        {
                            audio.clip = suspect[Random.Range(0, suspect.Length - 1)];
                            audio.Play();
                        }
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
            else
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (!audio.isPlaying)
                    {
                        audio.clip = civilian[Random.Range(0, civilian.Length - 1)];
                        audio.Play();
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
