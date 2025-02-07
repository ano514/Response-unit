using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName ="weapons")]
public class weapon : Item
{
    public GameObject prefab;
    public int magdazineSize;
    public int magazineCount;
    public float range;
    public float fireRate;
    public float spread;
    public int damage;
    public WeaponType type;
    public WeaponStyle weaponstyle;
    public FireMode firemode;
}

public enum WeaponType { Pistol, AR, SMG, Shotgun,}

public enum WeaponStyle { Primary, Secondary, Gadget}

public enum FireMode  { SemiAuto, Auto };