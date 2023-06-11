using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Noob : MonoBehaviour
{
    [SerializeField] public float hp = 10f, speed = 3f;
    [SerializeField] public Transform hq;
    //This will have a reference to the HQ so that the Noobs know where the HQ is and walk towards it.

    public Vector2 move; 
    public Rigidbody2D rigB;

    public void getDirection()
    {
        Vector3 relative = this.hq.position - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        //To find the direction to move to the castle, angle is set to the value by using the Math
        //formula of arctan(  (y2 - y1)/(x2 - x1)  )
    }

    public void walk(Vector2 angle)
    {
        this.rigB.MovePosition((Vector2)transform.position + (angle * this.speed * Time.deltaTime));
    }
}
