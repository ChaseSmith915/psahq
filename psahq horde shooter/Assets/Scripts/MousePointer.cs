using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public Camera Cam { get => cam; set => cam = value; }

    // Update is called once per frame
    void Update()
    {
        if(cam == null)
        {
            return;
        }
        Vector3 mouseXY = this.Cam.ScreenToWorldPoint(Input.mousePosition);
        mouseXY.z = 0f;
        //This is a 2D game so z is just left at 0.

        transform.position = mouseXY;
    }
}
