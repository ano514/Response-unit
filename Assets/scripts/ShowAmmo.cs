using UnityEngine;
using TMPro;

public class ShowAmmo : MonoBehaviour
{
    [SerializeField] private TMP_Text magazineSizeText;
    [SerializeField] private TMP_Text magdazineCountText;

    public void UpdateInfo(int magazineSize, int magazineCount)
    {
        magazineSizeText.text=magazineSize.ToString();
        int magazineCountAmount = magazineSize * magazineCount;
        magdazineCountText.text=magazineCountAmount.ToString();
    }

    public void UpdateAmmoUI(int magazineSize, int storedAmmo)
    {
         magazineSizeText.text = magazineSize.ToString();
        magdazineCountText.text = storedAmmo.ToString();
    }
}
