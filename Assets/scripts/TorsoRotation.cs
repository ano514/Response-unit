using UnityEngine;
using System.Collections;

public class TorsoRotation : MonoBehaviour
{
    private Animator anim;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int del;
    private void Start()
    {
        Reference();
    }
    void Update()
    {
        Cursor.visible = false;
    }

    void OnGUI()
    {
        var mousePos = Event.current.mousePosition;

        mousePos.x = Mathf.Clamp(mousePos.x+ minX, minX, maxX);
        mousePos.y = Mathf.Clamp(mousePos.y, minY, maxY);
        anim.SetFloat("Direction", mousePos.x/del);
    }
    private void Reference()
    {
        anim = GetComponent<Animator>();
    }
}
