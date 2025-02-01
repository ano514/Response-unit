using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar1 : MonoBehaviour
{
    private int baseVaule;
    private int maxVaule;
    [SerializeField] private Image fill;


    public void SetVaules(int _baseValue, int _maxVaule)
    {
        baseVaule = _baseValue;
        maxVaule = _maxVaule;
        CalculateFillAmount();
    }
    private void CalculateFillAmount()
    {
        float fillAmount = (float)baseVaule / (float)maxVaule;
        fill.fillAmount=fillAmount;
    }
}
