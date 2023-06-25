using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobType1 : Noob, IPunObservable
{
    //There is no Start method because the Noob abstract class has one for it.
    //But you may override it if you want.

    [SerializeField] private Animator anim;

    public override void Start()
    {
        
        base.Start();
        try
        {
            anim.SetInteger("skin", UnityEngine.Random.Range(1, 5));
        }
        catch(Exception ex)
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        //this.setDirection();
        //This adjusts the direction so that the Noob is facing the Object that it wants to follow.

        //this.walk(this.move);
        //After getting the direction, it then moves.
        //To see the implementation of both methods, please look at the Noob script.

        this.pv.RPC("walk", RpcTarget.All);
    }
}
