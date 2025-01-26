using UnityEngine;

public class AnimationEventControler : MonoBehaviour
{
    private Inventory inventory;
    private EquipmentManager manager;

    private void Start()
    {
        References();
    }

    public void DestroyWeapon()
    {
        Destroy(manager.currentGun);
    }

    public void InstantiateWeapon()
    {
        manager.currentGun = Instantiate(inventory.GetItem(manager.current).prefab);
    }

    public void References()
    {
        manager = GetComponent<EquipmentManager>();
        inventory = GetComponent<Inventory>();
    }
}
