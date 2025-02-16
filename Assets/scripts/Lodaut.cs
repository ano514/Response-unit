using UnityEngine;

public class Lodaut : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager equipmentManager;
    [SerializeField] public weapon weaponPrimary;
    [SerializeField] public weapon weaponSecondary;
    [SerializeField] public weapon flashbank;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reference();


    }
    private void Update()
    {
        if (inventory.GetItem(0)==null)
        {
            lodaut();
        }
    }

    private void Reference()
    {
        inventory = GetComponent<Inventory>();
        equipmentManager = GetComponent<EquipmentManager>();
    }
    public void lodaut()
    {
        if (LodautSaver.Primary != null && LodautSaver.Secondary != null)
        {
            inventory.AddItem(LodautSaver.Primary);
            inventory.AddItem(LodautSaver.Secondary);
        }
        else
        {
            inventory.AddItem(weaponPrimary);
            inventory.AddItem(weaponSecondary);
        }
        inventory.AddItem(flashbank);
        equipmentManager.EquipWeapon(inventory.GetItem(0));
    }
}
