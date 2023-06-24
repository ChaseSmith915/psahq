using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigBod;
    public Camera cam;
    public float speed = 5f, accelSpeed;
    public Animator animator;
    //Adjust speed if needed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal"), directionY = Input.GetAxisRaw("Vertical");
        this.rigBod.velocity = Vector2.Lerp(rigBod.velocity, new Vector2(directionX, directionY).normalized * this.speed, accelSpeed);

        //normalized is used to prevent the player from moving faster when pressing 2 arrow keys
        //at the same time.
        //E.g. It should not take you the same time to reach the right side by walking Northeast
        //compared to only moving East.

        //Communicate with Animator
        if (rigBod.velocity.x > 0.01 || rigBod.velocity.y > 0.01 || rigBod.velocity.x < -0.01 || rigBod.velocity.y < -0.01)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        animator.SetFloat("hSpd", rigBod.velocity.x);
        animator.SetFloat("vSpd", rigBod.velocity.y);

        /*

        Vector3 relative = this.cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90f;
        this.rigBod.rotation = angle;
        relative.Normalize();

        Vector3 mouseXY = transform.position;
        transform.position = mouseXY;
        */
        //This is to make the Player sprite face where the mouse is.
    }
}
