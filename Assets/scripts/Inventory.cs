using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private weapon[] weaponsAndGadetch;
    private Flashbank[] flashbanks;

    private BulletSpawner shooting;
    private AmmoManager ammoManager;
    private void Start()
    {
        Refrences();
        InitVariables();
    }

    public void AddItem(weapon newItem)
    {
        int index = (int)newItem.weaponstyle;
        if (weaponsAndGadetch[index] != null)
        {
            RemoveItem(index);
            Debug.Log("Odobrany Item");
        }
         weaponsAndGadetch[index] = newItem;
         ammoManager.InitAmmo((int)newItem.weaponstyle, newItem);
        }

   

    public weapon GetItem(int index)
    {
        return weaponsAndGadetch[index];
    }

    public void RemoveItem(int index)
    {
        weaponsAndGadetch[index] = null;
    }

    private void InitVariables()
    {
        weaponsAndGadetch = new weapon[3];

    }
    private void Refrences()
    {
        shooting = GetComponentInChildren<BulletSpawner>();
        ammoManager = GetComponent<AmmoManager>();
    }
}
