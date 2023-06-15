using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobType1 : Noob
{
    // Start is called before the first frame update
    void Start()
    {
        this.cur_hp = this.maxHP;
        hqXY = GameObject.Find("HQ").transform;
        Debug.Log(hqXY);
        this.rigB = GetComponent<Rigidbody2D>();
        //this.healthbar = GetComponent<HealthBar>();
        //this.healthbar.setHealth(this.cur_hp, this.maxHP);
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
