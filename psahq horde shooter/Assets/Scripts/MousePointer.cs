using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField] private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseXY = this.cam.ScreenToWorldPoint(Input.mousePosition);
        mouseXY.z = 0f;
        //This is a 2D game so z is just left at 0.

        transform.position = mouseXY;
    }
}
