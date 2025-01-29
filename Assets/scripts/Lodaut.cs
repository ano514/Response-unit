using UnityEngine;

public class Lodaut : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager equipmentManager;
    [SerializeField] public weapon weaponPrimary;
    [SerializeField] public weapon weaponSecondary;
    [SerializeField] public Flashbank flashbank;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reference();
        lodaut();

    }

    private void Reference()
    {
        inventory = GetComponent<Inventory>();
        equipmentManager = GetComponent<EquipmentManager>();
    }
    public void lodaut()
    {
        inventory.AddItem(weaponPrimary);
        inventory.AddItem(weaponSecondary);
        inventory.AddFlashbank(flashbank);
    }
}
