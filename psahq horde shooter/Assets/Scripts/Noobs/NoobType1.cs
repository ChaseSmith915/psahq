using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobType1 : Noob
{
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        this.setDirection();
        //This adjusts the direction so that the Noob is facing the Object that it wants to follow.

        this.walk(this.move);
        //After getting the direction, it then moves.
        //To see the implementation of both methods, please look at the Noob script.

    }
}
