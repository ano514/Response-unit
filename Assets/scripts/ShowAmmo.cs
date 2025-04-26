using UnityEngine;
using TMPro;

public class ShowAmmo : MonoBehaviour
{
    [SerializeField] private TMP_Text magazineSizeText;
    [SerializeField] private TMP_Text magdazineCountText;

    public void UpdateInfo(int magazineSize, int magazineCount)
    {
        int magazineCountAmount = magazineSize * magazineCount;
        UpdateAmmoUI(magazineSize, magazineCountAmount);
    }

    public void UpdateAmmoUI(int magazineSize, int storedAmmo)
    {
         magazineSizeText.text = magazineSize.ToString();
        magdazineCountText.text = storedAmmo.ToString();
    }
}
