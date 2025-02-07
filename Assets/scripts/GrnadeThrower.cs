using UnityEngine;

public class GrnadeThrower : MonoBehaviour
{
    public float throwForce = 20f;
    public GameObject greandePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ThrowGranade();
        }
    }
    void ThrowGranade()
    {
        GameObject granade = Instantiate(greandePrefab, transform.position, transform.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*throwForce);
    }
}
