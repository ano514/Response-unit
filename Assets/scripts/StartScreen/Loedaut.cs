using UnityEngine;

public class Loedaut : MonoBehaviour
{
    public weapon Primary1;
    public weapon Primary2;
    public weapon Secondary1;
    public weapon Secondary2;
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
            LodautSaver.Primary = Primary1;
        }
        else if (val == 1)
        {
            LodautSaver.Primary = Primary2;
        }
    }
    public void DropdownSecondary(int val)
    {
        if(val == 0)
        {
            LodautSaver.Secondary = Secondary1;
        }
        if (val == 1)
        {
            LodautSaver.Secondary = Secondary2;
        }

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
