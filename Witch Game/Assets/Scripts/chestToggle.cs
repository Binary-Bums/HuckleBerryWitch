using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestToggle : MonoBehaviour
{
    public GameObject chestCanvas;
    public KeyCode chestKey = KeyCode.C;

    private bool ischestCanvasOpen = false;
    // Start is called before the first frame update
    public void Start()
    {
        chestCanvas.SetActive(false);
    }

    // Update is called once per frame
    public void Updatethis()
    {
        if(Input.GetKeyDown(chestKey))
        {
            ischestCanvasOpen= !ischestCanvasOpen;
            chestCanvas.SetActive(ischestCanvasOpen);
        }
    }
}