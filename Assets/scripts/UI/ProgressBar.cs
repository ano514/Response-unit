using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private int baseVaule;
    private int maxVaule;
    [SerializeField] private Image fill;
    [SerializeField] private Text amount;


    public void SetVaules(int _baseValue, int _maxVaule)
    {
        baseVaule = _baseValue;
        maxVaule = _maxVaule;
        amount.text = baseVaule.ToString(); ;
        CalculateFillAmount();
    }
    private void CalculateFillAmount()
    {
        float fillAmount = (float)baseVaule / (float)maxVaule;
        fill.fillAmount=fillAmount;
    }
}
