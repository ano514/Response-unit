using UnityEngine;

public class Terorist : MonoBehaviour
{
    [SerializeField] weapon deafultWeapon = null;
    [SerializeField] private int CurrentAmmo;
    [SerializeField] private Transform GunHolder = null;
    private GameObject Current;
    private Animator anim;
    private void Start()
    {
        References();
        Deafaultweapon(deafultWeapon);
        InitAmmo();
    }
    private void Update()
    {
        if (CurrentAmmo <= 0)
        {
            Reload();
        }

    }
    private void EquipWeapon(weapon Weapon)
    {
        anim.SetInteger("Typ", (int)Weapon.type);
        Current = Instantiate(Weapon.prefab, GunHolder);
    }
    private void References()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Deafaultweapon(weapon Weapon)
        {
        EquipWeapon(Weapon);
        }

    private void InitAmmo()
    {
        CurrentAmmo = deafultWeapon.magdazineSize;
    }
    private void Reload()
    {
        CurrentAmmo = deafultWeapon.magdazineSize;
    }
}
