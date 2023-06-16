using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Noob : MonoBehaviour
{
    [SerializeField] public float cur_hp, maxHP = 10f, speed = 3f;
    public Transform hqXY;
    //hqXY will have a reference to the HQ so that the Noobs know where the HQ is and walk towards it.

    public Vector2 move; 
    public Rigidbody2D rigB;
    public HealthBar healthbar;

    public void setDirection()
    {
        Vector3 relative = this.hqXY.position - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        //To find the direction to move to the castle, angle is set to the value by using the Math
        //formula of arctan(  (y2 - y1)/(x2 - x1)  )

        this.rigB.rotation = angle;
        relative.Normalize();
        //Normalize adjusts the Vector3 so that when the Noobs move diagonally, it should still move
        //at the same pace as just moving in one direction.

        this.move = relative;
    }

    public void walk(Vector2 angle)
    {
        this.rigB.MovePosition((Vector2)transform.position + (angle * this.speed * Time.deltaTime));
    }
    public void changeHP(float amount)
    {
        this.cur_hp += amount;
        this.healthbar.setHealth(this.cur_hp, this.maxHP);
        //If the amount is a negative number, then the Noob is taking damage.

        if (this.cur_hp <= 0)
            Destroy(this.gameObject);
        
    }

    public void Start()
    {
        this.cur_hp = this.maxHP;
        this.hqXY = GameObject.Find("HQ").transform;
        this.rigB = GetComponent<Rigidbody2D>();

        this.healthbar = GetComponentInChildren<HealthBar>();
        //The GetComponentInChildren method gets any component that the child GameObjects that
        //the parent GameObject has.
        //E.g. If you attached the Main Camera into the player and the Main Camera had a script,
        //you can use the GetComponentInChildren method to get that Component the Main Camera had.

        this.healthbar.setHealth(this.cur_hp, this.maxHP);
        //The setHealth method belongs to the Health Bar class. It just displays the current
        //health by dividing the cur_hp and maxHP.
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            this.changeHP(-3);
        }
    }
}
