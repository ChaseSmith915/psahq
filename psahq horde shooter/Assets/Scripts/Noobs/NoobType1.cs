using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobType1 : Noob
{
    //There is no Start method because the Noob abstract class has one for it.
    //But you may override it if you want.

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
