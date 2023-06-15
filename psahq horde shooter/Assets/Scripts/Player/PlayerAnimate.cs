using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Animator animator;

    public Camera Cam { get => cam; set => cam = value; }

    private float mouseX;
    private float mouseY;
    public int dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = this.Cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        //This is a 2D game so z is just left at 0.

        mouseX = mousePos.x;
        mouseY = mousePos.y;

        if ((mouseX > transform.position.x - 1 && mouseX < transform.position.x + 1) && (mouseY < transform.position.y))
        {
            dir = 1;
        }
        else if ((mouseX > transform.position.x) && (mouseY < transform.position.y))
        {
            dir = 2;
        }
        else if ((mouseX > transform.position.x) && (mouseY < transform.position.y + 1 && mouseY > transform.position.y - 1))
        {
            dir = 3;
        }
        else if ((mouseX > transform.position.x) && (mouseY > transform.position.y - 1))
        {
            dir = 4;
        }
        else if ((mouseX > transform.position.x - 1 && mouseX < transform.position.x + 1) && (mouseY > transform.position.y))
        {
            dir = 5;
        }
        else if ((mouseX < transform.position.x) && (mouseY > transform.position.y))
        {
            dir = 6;
        }
        else if ((mouseX < transform.position.x) && (mouseY < transform.position.y + 1 && mouseY > transform.position.y - 1))
        {
            dir = 7;
        }
        else if ((mouseX < transform.position.x) && (mouseY < transform.position.y))
        {
            dir = 8;
        }

        animator.SetInteger("dir", dir);
    }
}
