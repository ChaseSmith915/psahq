using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigBod;
    //[SerializeField] private Camera cam;
    [SerializeField] private float speed = 5f, accelSpeed;
    [SerializeField] private Animator animator;
    //Adjust speed if needed;
    [SerializeField] private TMP_Text score;
    private int noobCount, id;
    [SerializeField] private PhotonView photonV;
    [SerializeField] private GameObject canvasOverlap; 
    //canvasOverlap is just any Canvas gameObjects that take up the entire screen.

    public int getID()
    {
        return this.id;
    }

    public void setID(int num)
    {
        this.id = num;
    }

    public int getNoobCount()
    {
        return this.noobCount;
    }

    public void setText(string word)
    {
        this.score.text = word;
    }

    public void setNoobCount(int num)
    {
        this.noobCount = num;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.noobCount = 0;

        if (!this.photonV.IsMine)
        {
            Destroy(this.canvasOverlap);
            //Because each Player has their own screen Canvas that takes up the screen,
            //it would cause us to have multiple screen Canvases on our screen and so
            //we must have a reference to the screen Canvas and destroy copies of it.
        }
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
