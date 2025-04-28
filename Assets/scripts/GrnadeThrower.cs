using UnityEngine;
using UnityEngine.Rendering.UI;

public class GrnadeThrower : MonoBehaviour
{
    public float throwForce = 20f;
    public GameObject greandePrefab;
    public PlayerHUD hud;
    public Inventory inventory;

    private void Start()
    {
        Reference();

    }
    void Update()

    {
        weapon currentWeapon = inventory.GetItem(2);
        int ammo = currentWeapon.magdazineSize;
        if ((int)currentWeapon.weaponstyle == 2) 

        {
            hud.UpdateWeaponAmmoUI(1, ammo);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ammo + 1 >= 0)
            {
                ThrowGranade();
                currentWeapon.magdazineSize -= 1;
            }
            else
            {
                Debug.Log("haha uz nemas granaty");
            }

        }
    }
    private void Reference()
    {
        hud = transform.root.GetComponent<PlayerHUD>();
        inventory = transform.root.GetComponent<Inventory>();
    }
        void ThrowGranade()
    {
        GameObject granade = Instantiate(greandePrefab, transform.position, transform.rotation);
        Rigidbody rb = granade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*throwForce);
    }
}
