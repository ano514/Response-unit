using UnityEngine;
using UnityEngine.Rendering;

public class FlashbangEffect : MonoBehaviour
{
    public Volume volume;
    public CanvasGroup AplhaController;
    public AudioSource bang;

    private bool on = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FlashBanged()
    {
        volume.GetComponents<Volume>();
    }
}
