using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;
    [SerializeField]private float delay = 1000f;
    private void OnTriggerStay(Collider other)
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            delay = 50f;
            playerg.SetActive(false);
            player.position = destination.position;
            playerg.SetActive(true);
        }
    }
}
