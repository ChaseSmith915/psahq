using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigBod;
    [SerializeField] private float speed = 5f;
    //Adjust speed if needed;

    // Start is called before the first frame update
    void Start()
    {
        this.rigBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal"), directionY = Input.GetAxisRaw("Vertical");
        this.rigBod.velocity = new Vector2(directionX, directionY).normalized * this.speed;
        //normalized is used to prevent the player from moving faster when pressing 2 arrow keys
        //at the same time.
        //E.g. It should not take you the same time to reach the right side by walking Northeast
        //compared to only moving East.
    }
}
