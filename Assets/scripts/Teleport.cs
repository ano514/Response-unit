using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;
    private void OnTriggerStay(Collider other)
    {
        playerg.SetActive(false);
        player.position = destination.position;
        playerg.SetActive(true);
    }
}
