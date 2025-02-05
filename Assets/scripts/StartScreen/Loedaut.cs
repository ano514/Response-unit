using UnityEngine;

public class Loedaut : MonoBehaviour
{
    private weapon Primary;
    private weapon Secondary;
    public GameObject lodautScreen;
    public GameObject startScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropdownPrimary(int val)
    {
        if (val == 0)
        {
        }
    }
    public void DropdownSecondary(int val)
    {

    }
    public void OpenLodaut()
    {
        lodautScreen.SetActive(true);
        startScreen.SetActive(false);
    }
    public void CloseLodaut()
    {
        lodautScreen.SetActive(false);
        startScreen.SetActive(true);
    }
}
